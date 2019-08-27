using Message.Core.Extensions;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Account;
using Message.IService;
using Message.UI.Areas.Admin.Validation.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly string CaptchaCodeSessionName = "CaptchaCode";
        private readonly IUserInfoService _userInfoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(IUserInfoService userInfoService, IHttpContextAccessor httpContextAccessor)
        {
            _userInfoService = userInfoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Admin/Account/SignIn")]
        [ValidateAntiForgeryToken]
        public async Task<string> SignInAsync(ViewUserInfo model)
        {
            BaseResult result = new BaseResult();
            try
            {
                ViewUserInfoValidation entityValidation = new ViewUserInfoValidation();
                ValidationResult validationResilt = await entityValidation.ValidateAsync(model);
                if (validationResilt.IsValid)
                {
                    //判断验证码
                    if (!model.CaptchaCode.Equals(HttpContext.Session.GetString(CaptchaCodeSessionName), StringComparison.OrdinalIgnoreCase))
                    {
                        result.Code = 100;
                        result.Msg = "验证码错误!";
                    }
                    else
                    {
                        //验验证用户名密码
                        model.Ip = HttpContext.GetClientUserIp();
                        UserInfo entityUserInfo = await _userInfoService.CheckUserAsync(model.UserName, model.Password, model.Ip);
                        if (entityUserInfo == null)
                        {
                            result.Code = 1;
                            result.Msg = "用户名或密码错误!";
                        }
                        else
                        {
                            if (entityUserInfo.BisLock.Value)
                            {
                                result.Code = 2;
                                result.Msg = "已被锁定,请联系管理员解锁!";
                            }
                            else
                            {
                                List<Claim> lstClaim = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.Name, entityUserInfo.SloginName),
                                    new Claim("Id",entityUserInfo.Id.ToString()),
                                    new Claim("SuserName",entityUserInfo.SuserName.ToString()),
                                    new Claim("SloginLastIp",entityUserInfo.SloginLastIp.ToString()),
                                    new Claim("TloginLastTime",entityUserInfo.TloginLastTime.ToString())
                                };
                                ClaimsIdentity claimsIdentity = new ClaimsIdentity(lstClaim, CookieAuthenticationDefaults.AuthenticationScheme);
                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                                _httpContextAccessor.HttpContext.Session.SetInt32("Id", entityUserInfo.Id);
                                _httpContextAccessor.HttpContext.Session.SetString("SloginName", entityUserInfo.SloginName);
                                _httpContextAccessor.HttpContext.Session.SetString("SuserName", entityUserInfo.SuserName);
                                _httpContextAccessor.HttpContext.Session.SetString("SloginLastIp", entityUserInfo.SloginLastIp);
                                _httpContextAccessor.HttpContext.Session.SetString("TloginLastTime", entityUserInfo.TloginLastTime.ToString());
                                result.Code = 0;
                                result.Msg = "登陆成功!";
                            }
                        }
                    }
                }
                else
                {
                    result.Code = 3;
                    result.Msg = validationResilt.ToString("<br/>");
                }
            }
            catch (Exception ex)
            {
                result.Code = 4;
                result.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(result);
        }
        public IActionResult GetCaptchaImage()
        {
            string sCaptchaCode = CaptchaHelper.GenerateCaptchaCode();
            CaptchaResult result = CaptchaHelper.GetImage(116, 36, sCaptchaCode);
            HttpContext.Session.SetString(CaptchaCodeSessionName, sCaptchaCode);
            return new FileStreamResult(new MemoryStream(result.CaptchaByteData), "image/png");
        }
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

    }
}