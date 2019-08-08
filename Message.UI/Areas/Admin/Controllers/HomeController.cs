using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Message.Core.Extensions;
using System.Threading.Tasks;
using Message.Entity.ViewEntity.Home;

namespace Message.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRoleService _UserRoleService;
        private readonly IUserInfoService _UserInfoService;
        private readonly IRoleMenuService _RoleMenuService;
        private readonly IMenuService _MenuService;
        private readonly IUploadFileInfoService _uploadFileInfoService;




        public HomeController(IHttpContextAccessor httpContextAccessor, IUserRoleService userRoleService, IUserInfoService UserInfoService, IRoleMenuService RoleMenuService, IMenuService MenuService, IUploadFileInfoService uploadFileInfoService)
        {
            _httpContextAccessor = httpContextAccessor;
            _UserRoleService = userRoleService;
            _UserInfoService = UserInfoService;
            _RoleMenuService = RoleMenuService;
            _MenuService = MenuService;
            _uploadFileInfoService = uploadFileInfoService;
        }
        [Route("/Admin/Home/Index")]
        public async Task<IActionResult> IndexAsync()
        {
            int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            UserInfo entityUserInfo = await _UserInfoService.GetUserInfoAsync(new UserInfo() { Id = iUserId });
            if (entityUserInfo != null)
            {

                UploadFileInfo entityUploadFileInfo = await _uploadFileInfoService.GetFileInfoAsync(entityUserInfo.IfileInfoId);
                ViewData["SuserName"] = entityUserInfo.SuserName;
                if (entityUploadFileInfo != null)
                {
                    ViewData["Avatar"] = entityUploadFileInfo.SrelativePath;
                }
                else
                {
                    ViewData["Avatar"] = "/Images/DefaultUserHeadImage.jpg";
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<string> GetMenuAsync()
        {
            string sUserMenuKey = User.Identity.Name + "_Menu";
            List<TreeItem<ViewMenu>> lstTreeItem;
            lstTreeItem = RedisHelper.Get<List<TreeItem<ViewMenu>>>(sUserMenuKey);
            RedisHelper.Del(sUserMenuKey);
            if (lstTreeItem?.Count > 0)
            {
                return JsonHelper.ObjectToJSON(lstTreeItem);
            }
            else
            {
                List<ViewMenu> lstViewMenu = new List<ViewMenu>();
                int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                //查询用户拥有角色集合
                List<UserRole> lstUserRoleList = await _UserInfoService.GetUserRoleListAsync(new UserRole() { IuserId = iUserId });
                //查询角色所拥有的菜单集合
                List<RoleMenu> lstRoleMenuList = new List<RoleMenu>();
                if (lstUserRoleList?.Count > 0)
                {
                    foreach (UserRole entityUserRole in lstUserRoleList)
                    {
                        List<RoleMenu> lstRoleMenu = await _RoleMenuService.GetRoleMenuListAsync(new RoleMenu() { IroleId = entityUserRole.IroleId });
                        if (lstRoleMenu?.Count > 0)
                        {
                            lstRoleMenuList.AddRange(lstRoleMenu);
                        }
                    }
                    //去重
                    lstRoleMenuList = lstRoleMenuList.Where((x, i) => lstRoleMenuList.FindIndex(z => z.ImenuId == x.ImenuId) == i).ToList();
                    //获取菜单
                    List<Menu> lstUserMenu = await _MenuService.GetRoleMenuListAnyncAsync(lstRoleMenuList);
                    if (lstUserMenu?.Count > 0)
                    {
                        //排序
                        lstUserMenu = lstUserMenu.OrderBy(x => x.Isort).ToList();
                        lstUserMenu.ForEach(entityMenu =>
                        {
                            ViewMenu entityViewMenu = new ViewMenu();
                            entityViewMenu.Id = entityMenu.Id;
                            entityViewMenu.ParentId = entityMenu.IparentId == -1 ? 0 : entityMenu.IparentId;
                            entityViewMenu.DisplayName = entityMenu.Sname;
                            entityViewMenu.IconUrl = entityMenu.SiconUrl;
                            entityViewMenu.LinkUrl = entityMenu.SlinkUrl;
                            entityViewMenu.Target = "";
                            lstViewMenu.Add(entityViewMenu);
                        });
                    }
                }
                lstTreeItem = lstViewMenu.GenerateTree(x => x.Id, x => x.ParentId).ToList();
                RedisHelper.Set(sUserMenuKey, lstTreeItem);
            }
            return JsonHelper.ObjectToJSON(lstTreeItem);
        }
        public IActionResult Main()
        {
            return View();
        }

    }
}