using Message.Core.Models;
using Message.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IRoleMenuService
    {
        PageInfo<RoleMenu> GetPageList(PageInfo<RoleMenu> pageInfo, RoleMenu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<List<RoleMenu>> GetRoleMenuListAsync(RoleMenu entityRoleMenu, string sOperator = null);
    }
}
