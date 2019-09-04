using AutoMapper;
using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity;
using Message.Entity.ViewEntity.UserInfo;
using Message.IService;
using Message.UI.Areas.Admin.Validation.UserInfo;
using Message.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class UserInfoController : BaseAdminController
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IUserRoleService _userRoleService;
        private readonly IUploadFileInfoService _uploadFileInfoService;
        private readonly IMapper _mapper;

        public UserInfoController(IUserInfoService userInfoService, IUserRoleService userRoleService, IUploadFileInfoService uploadFileInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _userRoleService = userRoleService;
            _uploadFileInfoService = uploadFileInfoService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return base.List();
        }
        public string LoadData(PageInfo<UserInfo> pageInfo, UserInfo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            pageInfo = _userInfoService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
            return JsonHelper.ObjectToJSON(pageInfo);
        }
        public IActionResult AddOrModify()
        {
            return base.Edit();
        }
        /// <summary>
        /// 添加或修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync([FromForm]AddOrModifyUserInfo model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    AddOrModifyUserInfoValidation validationRules = new AddOrModifyUserInfoValidation();
                    ValidationResult validationResilt = await validationRules.ValidateAsync(model);
                    if (validationResilt.IsValid)
                    {
                        string sDefaultUserPwd = GetJsonValue("DefaultUserPwd");
                        model.SloginPwd = sDefaultUserPwd;
                        UserInfo resultUserInfo = await _userInfoService.AddOrModifyUserInfoAsync(model, User.Identity.Name);
                        if (resultUserInfo != null)
                        {
                            baseResult.Code = 0;
                            baseResult.Msg = "操作成功!";
                        }
                        else
                        {
                            baseResult.Code = 1;
                            baseResult.Msg = "操作失败!";
                        }
                    }
                    else
                    {
                        baseResult.Code = 3;
                        baseResult.Msg = validationResilt.ToString("<br>");
                    }
                }
            }
            catch (System.Exception ex)
            {
                baseResult.Code = 4;
                baseResult.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }
        /// <summary>
        /// 更改用户锁定状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> ChangeUserLockStates([FromForm]ChangeUserStatus model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (await _userInfoService.ChangeUserLockStatusAsync(model, User.Identity.Name))
                {
                    baseResult.Code = 0;
                    baseResult.Msg = "修改成功!";
                }
                else
                {
                    baseResult.Code = 1;
                    baseResult.Msg = "修改失败!";
                }
            }
            catch (System.Exception ex)
            {
                baseResult.Code = 3;
                baseResult.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(baseResult);

        }

        public async Task<IActionResult> PersonalInfo()
        {
            int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            if (iUserId > 0)
            {
                UserInfo entityUserInfo = await _userInfoService.GetUserInfoAsync(new UserInfo() { Id = iUserId });
                if (entityUserInfo != null)
                {
                    PersonalInfo entityPersonalInfo = new PersonalInfo();
                    entityPersonalInfo.SloginName = entityUserInfo.SloginName;
                    entityPersonalInfo.SuserName = entityUserInfo.SuserName;
                    entityPersonalInfo.SuserEmail = entityUserInfo.SuserEmail;
                    entityPersonalInfo.SuserPhone = entityUserInfo.SuserPhone;
                    if (entityUserInfo.IfileInfoId > 0)
                    {
                        UploadFileInfo entityUploadFileInfo = await _uploadFileInfoService.GetFileInfoAsync(entityUserInfo.IfileInfoId);
                        entityPersonalInfo.Uid = entityUploadFileInfo.Uid;
                        entityPersonalInfo.sAvatar = string.IsNullOrWhiteSpace(entityUploadFileInfo.SrelativePath) ? "/Images/login_tx.jpg" : entityUploadFileInfo.SrelativePath;
                    }
                    else
                    {
                        entityPersonalInfo.sAvatar = "/Images/login_tx.jpg";
                    }
                    return base.Empty(entityPersonalInfo);
                }
            }
            return base.Empty();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> PersonalInfo([FromForm] PersonalInfo model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                if (iUserId > 0)
                {
                    UserInfo entityUserInfo = await _userInfoService.GetUserInfoAsync(new UserInfo() { Id = iUserId });
                    if (entityUserInfo != null)
                    {
                        if (model != null)
                        {
                            PersonalInfoValidation validationRules = new PersonalInfoValidation();
                            ValidationResult validationResilt = await validationRules.ValidateAsync(model);
                            if (validationResilt.IsValid)
                            {
                                entityUserInfo.SuserName = model.SuserName;
                                entityUserInfo.SuserEmail = model.SuserEmail;
                                entityUserInfo.SuserPhone = model.SuserPhone;
                                if (!string.IsNullOrWhiteSpace(model.Uid.ToString()))
                                {
                                    UploadFileInfo entityUploadFileInfo = await _uploadFileInfoService.GetFileInfoAsync(new UploadFileInfo() { Uid = model.Uid });
                                    if (entityUploadFileInfo != null)
                                    {
                                        entityUserInfo.IfileInfoId = entityUploadFileInfo.Id;
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(model.SoldPassWord) && !string.IsNullOrWhiteSpace(model.SnewPassWord) && !string.IsNullOrWhiteSpace(model.SconfirmPassWord))
                                {
                                    //判断旧密码是否正确
                                    if (await _userInfoService.CheckUserAsync(entityUserInfo.SloginName, model.SoldPassWord) != null)
                                    {
                                        entityUserInfo.SloginPwd = model.SconfirmPassWord;
                                        //修改密码
                                        _userInfoService.ChangeUserPassWord(entityUserInfo, User.Identity.Name);
                                        baseResult.Code = 0;
                                        baseResult.Msg = "修改成功!";
                                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                                    }
                                    else
                                    {
                                        baseResult.Code = 4;
                                        baseResult.Msg = "旧密码错误!";
                                    }
                                }
                                else
                                {

                                    await _userInfoService.AddOrModifyUserInfoAsync(_mapper.Map<AddOrModifyUserInfo>(entityUserInfo), User.Identity.Name);
                                    baseResult.Code = 0;
                                    baseResult.Msg = "修改成功!";
                                }
                            }
                            else
                            {

                                baseResult.Code = 3;
                                baseResult.Msg = validationResilt.ToString("<br>");
                            }
                        }
                    }
                    else
                    {
                        baseResult.Code = 2;
                        baseResult.Msg = "未知错误!";
                    }
                }
            }
            catch (Exception ex)
            {
                baseResult.Code = 4;
                baseResult.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string DeleteRange(int[] arrUserId)
        {
            BaseResult baseResult = new BaseResult();
            if (_userInfoService.DeleteRange(arrUserId, User.Identity.Name))
            {
                baseResult.Code = 0;
                baseResult.Msg = "删除成功!";
            }
            else
            {
                baseResult.Code = 1;
                baseResult.Msg = "删除失败!";
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }

        [HttpGet]
        public async Task<string> GetUserListAsync()
        {
            List<UserInfo> lstUserInfo = await _userInfoService.GetUserInfoListAsync();
            List<ViewSelect> lstViewSelectUser = new List<ViewSelect>();
            if (lstUserInfo?.Count > 0)
            {
                foreach (UserInfo entityUserInfo in lstUserInfo)
                {
                    ViewSelect entity = new ViewSelect();
                    entity.id = entityUserInfo.Id;
                    entity.name = entityUserInfo.SloginName;
                    lstViewSelectUser.Add(entity);
                }
            }
            return JsonHelper.ObjectToJSON(lstViewSelectUser);
        }
    }
}