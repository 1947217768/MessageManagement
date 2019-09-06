using Message.Core.Models;
using Message.Entity.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IRoleMenuService
    {
        PageInfo<RoleMenu> GetPageList(PageInfo<RoleMenu> pageInfo, RoleMenu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<List<RoleMenu>> GetRoleMenuListAsync(RoleMenu entityRoleMenu, string sOperator = null);
        Task<List<RoleMenu>> AddOrDeleteMenuRoleAsync(int iMneuId, List<int> lstRoleId, string sOperator);
        Task<List<RoleMenu>> AddOrDeleteRoleMenuAsync(int iRoleId, List<int> lstMenuId, string sOperator);


        List<RoleMenu> SelectALL(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        RoleMenu Select(int id, string sOperator = null);
        RoleMenu Select(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityRoleMenu">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<RoleMenu>> SelectALLAsync(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<RoleMenu> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityRoleMenu">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<RoleMenu> SelectAsync(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

    }
}
