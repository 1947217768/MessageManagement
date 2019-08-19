using Message.Core.Repository;
using Message.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Message.IRepository
{
    public interface IRoleMenuRepository : IMessageManagementRepository<RoleMenu>
    {

        /// <summary>
        /// 新增或删除角色菜单
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="lstRoleId"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<RoleMenu>> AddOrDeleteMenuRoleAsync(int iMneuId, List<int> lstRoleId, string sOperator);

        Task<List<RoleMenu>> AddOrDeleteRoleMenuAsync(int iRoleId, List<int> lstMenuId, string sOperator);
    }
}
