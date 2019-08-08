using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IRepository;
using Message.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Service
{
    public class RoleMenuService : IRoleMenuService
    {
        private readonly IRoleMenuRepository _RoleMenuRepository;
        private readonly IMenuRepository _menuRepository;
        public RoleMenuService(IRoleMenuRepository RoleMenuRepository, IMenuRepository menuRepository)
        {
            _RoleMenuRepository = RoleMenuRepository;
            _menuRepository = menuRepository;
        }
        public PageInfo<RoleMenu> GetPageList(PageInfo<RoleMenu> pageInfo, RoleMenu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RoleMenuRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<RoleMenu>> GetRoleMenuListAsync(RoleMenu entityRoleMenu, string sOperator = null)
        {
            if (entityRoleMenu != null)
            {
                List<RoleMenu> lstMenu = await _RoleMenuRepository.SelectALLAsync(entityRoleMenu, sOperator);
                return lstMenu;
            }
            return null;
        }
    }
}
