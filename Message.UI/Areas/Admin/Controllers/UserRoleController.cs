using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class UserRoleController : BaseAdminController
    {
        private readonly IUserRoleService _UserRoleService;
        public UserRoleController(IUserRoleService UserRoleService, IMenuService menuService) : base(menuService)
        {
            _UserRoleService = UserRoleService;
        }
        public string LoadData(PageInfo<UserRole> pageInfo, UserRole oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_UserRoleService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        [HttpGet]
        public async Task<List<int>> GetUserRoleIdList([FromQuery]int iUserId)
        {
            List<UserRole> lstUserRole = await _UserRoleService.GetRoleListAsync(new UserRole() { IuserId = iUserId });
            if (lstUserRole?.Count > 0)
            {
                return lstUserRole.Select(x => x.IroleId).ToList();
            }
            return null;
        }
        [HttpGet]
        public async Task<List<int>> GetRoleUserIdListAsync([FromQuery]int iRoleId)
        {
            List<UserRole> lstUserRole = await _UserRoleService.GetRoleListAsync(new UserRole() { IroleId = iRoleId });
            if (lstUserRole?.Count > 0)
            {
                return lstUserRole.Select(x => x.IuserId).ToList();
            }
            return null;
        }
    }
}