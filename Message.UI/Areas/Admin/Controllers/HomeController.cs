using Message.Core.Extensions;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.Redis;
using Message.Entity.ViewEntity.Home;
using Message.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            List<TreeItem<ViewMenu>> lstTreeItem = await RedisMethod.GetUserTreeMenuAsync(iUserId, -1, () => GetUserTreeMenuAsync(iUserId));
            return JsonHelper.ObjectToJSON(lstTreeItem);
        }

        public async Task<List<TreeItem<ViewMenu>>> GetUserTreeMenuAsync(int iUserId)
        {
            List<ViewMenu> lstViewMenu = new List<ViewMenu>();
            List<Menu> lstUserMenu = new List<Menu>();
            //查询角色所拥有的菜单集合
            lstUserMenu = await RedisMethod.GetUserMenuAsync(iUserId, -1, () => _MenuService.GetRoleMenuListAsync(iUserId));
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
            return lstViewMenu.GenerateTree(x => x.Id, x => x.ParentId).ToList();
        }
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Error(int iErrorCode)
        {
            string sMsg = string.Empty;
            switch (iErrorCode)
            {
                case 1:
                    sMsg = "参数错误!";
                    break;
                case 2:
                    sMsg = "菜单ID不匹配!";
                    break;
                case 3:
                    sMsg = "没有权限!";
                    break;
                case 4:
                    sMsg = "Action不匹配!";
                    break;
                default:
                    sMsg = "未知错误!";
                    break;
            }
            ViewBag.Msg = sMsg;
            return View();
        }
    }
}