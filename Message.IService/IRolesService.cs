using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IRolesService
    {
        PageInfo<Roles> GetPageList(PageInfo<Roles> pageInfo, Roles oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        List<Roles> GetRolesList(Roles entityRoles = null);

        /// <summary>
        /// 新增或修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Roles> AddOrModifyAsync(AddOrModifyRoles model, string sOperator);

        bool DeleteRange(int[] arrId, string sOperator);
    }
}