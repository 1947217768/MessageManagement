using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class RoleMenuController : BaseAdminController
    {
        private readonly IRoleMenuService _roleMenuService;
        public RoleMenuController(IRoleMenuService roleMenuService)
        {
            _roleMenuService = roleMenuService;
        }
        public string LoadData(PageInfo<RoleMenu> pageInfo, RoleMenu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_roleMenuService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        [HttpGet]
        public async Task<List<int>> GetMenuRoleAsync([FromQuery]int iMenuId)
        {
            //获取菜单角色列表
            List<RoleMenu> lstMenuRole = await _roleMenuService.GetRoleMenuListAsync(new RoleMenu() { ImenuId = iMenuId });
            if (lstMenuRole?.Count > 0)
            {
                return lstMenuRole.Select(x => x.IroleId).ToList();
            }
            return null;
        }
        public async Task<List<int>> GetRoleMenuAsync([FromQuery]int iRoleId)
        {
            List<RoleMenu> lstRoleMenu = await _roleMenuService.GetRoleMenuListAsync(new RoleMenu() { IroleId = iRoleId }); ;
            if (lstRoleMenu?.Count > 0)
            {
                return lstRoleMenu.Select(x => x.ImenuId).ToList();
            }
            return null;
        }
    }
}