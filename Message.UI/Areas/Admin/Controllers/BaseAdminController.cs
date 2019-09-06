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
        private readonly IMenuService _menuService;
        private readonly IMenuActionService _menuActionService;
        private readonly ISystemActionService _systemActionService;
        public BaseAdminController()
        {
            _menuService = AppDependencyResolver.Current.GetService<IMenuService>();
            _menuActionService = AppDependencyResolver.Current.GetService<IMenuActionService>();
            _systemActionService = AppDependencyResolver.Current.GetService<ISystemActionService>();
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            string sAreaName = context.ActionDescriptor.RouteValues["area"].ToString();
            string sControllerName = context.ActionDescriptor.RouteValues["controller"].ToString();
            string sActionName = context.ActionDescriptor.RouteValues["action"].ToString();
            int iMenuId = Convert.ToInt32(context.HttpContext.Request.Query["iPageId"]);
            int iActionId = Convert.ToInt32(context.HttpContext.Request.Query["iMethodId"]);
            if (sAreaName == "Admin" && sActionName == "Index")
            {
                if (string.IsNullOrWhiteSpace(sAreaName) || string.IsNullOrWhiteSpace(sControllerName) || string.IsNullOrWhiteSpace(sActionName) || iMenuId == 0)
                {
                    context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=1");
                }
                else
                {
                    if (iMenuId > 0 && iActionId == 0 && sAreaName == "Admin" && sActionName == "Index")
                    {
                        if (await _menuService.CheckMenuControllerNameActionNameAsync(sAreaName, sControllerName, sActionName, iMenuId))
                        {
                            //检查用户菜单权限
                            if (await _menuService.CheckUserMenuPowerAsync(iUserId, iMenuId))
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
                }
            }
            else
            {
                if (iMenuId > 0 && iActionId > 0)
                {
                    if (await _systemActionService.CheckControllerNameActionNameAsync(sAreaName, sControllerName, sActionName, iActionId))
                    {
                        //检查用户菜单权限
                        if (await _menuService.CheckUserMenuPowerAsync(iUserId, iMenuId))
                        {
                            //检查MenuAction权限
                            MenuAction entityMenuAction = await _menuActionService.CheckMenuActionPowerAsync(iMenuId, iActionId);
                            if (entityMenuAction != null)
                            {
                                if (!entityMenuAction.BisValid.Value)
                                {

                                }
                                else
                                {
                                    //Action无效
                                    context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=3");
                                }
                            }
                            else
                            {
                                context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=3");
                            }
                        }
                        else
                        {
                            context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=3");
                        }
                    }
                    else
                    {
                        context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=4");
                    }
                }
                else
                {
                    context.Result = new RedirectResult("/Admin/Home/Error?iErrorCode=1");
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
        public IActionResult List(int iPageId)
        {
            ViewData["iPageType"] = 0;
            List<MenuAction> lstMenuAction = _menuActionService.SelectALL(new MenuAction() { ImenuId = iPageId });
            ViewBag.lstMenuAction = lstMenuAction;
            return View();
        }
        public IActionResult Edit(int iPageId)
        {
            ViewData["iPageType"] = 1;
            List<MenuAction> lstMenuAction = _menuActionService.SelectALL(new MenuAction() { ImenuId = iPageId });
            ViewBag.lstMenuAction = lstMenuAction;
            return View();
        }
        public IActionResult Empty(int iPageId, object model = null)
        {
            ViewData["iPageType"] = 2;
            List<MenuAction> lstMenuAction = _menuActionService.SelectALL(new MenuAction() { ImenuId = iPageId });
            ViewBag.lstMenuAction = lstMenuAction;
            return View(model);
        }
    }
}
