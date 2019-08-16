using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Message.UI.Models;
using Message.Entity.Mapping;
using Message.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Message.IService;

namespace Message.UI.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public abstract class BaseAdminController : Controller
    {
        private readonly IMenuService _MenuService;
        public BaseAdminController()
        {
            _MenuService = AppDependencyResolver.Current.GetService<IMenuService>();
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            string sAreaName = context.ActionDescriptor.RouteValues["area"].ToString();
            string sControllerName = context.ActionDescriptor.RouteValues["controller"].ToString();
            string sActionNmae = context.ActionDescriptor.RouteValues["action"].ToString();
            int iMenuId = Convert.ToInt32(context.HttpContext.Request.Query["Id"]);
            if (string.IsNullOrWhiteSpace(sAreaName) || string.IsNullOrWhiteSpace(sControllerName) || string.IsNullOrWhiteSpace(sActionNmae) || iMenuId == 0)
            {
                // context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=1");
            }
            else
            {
                if (await _MenuService.CheckMenuActionAsync(sAreaName, sControllerName, sActionNmae, iMenuId))
                {
                    if (await _MenuService.CheckUserMenuPowerAsync(iUserId, iMenuId))
                    {

                    }
                    else
                    {
                        context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=3");
                    }
                }
                else
                {
                    context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=2");
                }
            }
            await base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// 读取appsettings.json配置文件
        /// </summary>
        /// <param name="sKey">key</param>
        /// <param name="appsettings">路径默认appsettings.json</param>
        /// <returns>值</returns>
        public string GetJsonValue(string sKey, string sPath = "appsettings.json")
        {
            var builder = new ConfigurationBuilder().AddJsonFile(sPath);
            var configurationRoot = builder.Build();
            string sValue = configurationRoot.GetSection(sKey).Value.ToString();
            return sValue;
        }
        public IActionResult List()
        {
            ViewData["iPageType"] = 0;
            return View();
        }
        public IActionResult Edit()
        {
            ViewData["iPageType"] = 1;
            return View();
        }
    }
}
