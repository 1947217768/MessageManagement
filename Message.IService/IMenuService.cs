using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IMenuService
    {
        PageInfo<Menu> GetPageList(PageInfo<Menu> pageInfo, Menu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 查询用户拥有的菜单
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="sOperator">操作人</param>
        /// <returns></returns>
        Task<List<Menu>> GetRoleMenuListAsync(int iUserId, string sOperator = null);

        Task<Menu> AddOrModifyMenuAsync(AddOrModifyMenu model, string sOperator);

        Task<Menu> ChangeMenuStateAsync(ChangeMenuState model, string sOperator);

        Task<List<Menu>> GetMenuListAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);
        /// <summary>
        /// 检查菜单控制器与Action是否匹配
        /// </summary>
        /// <param name="sControllerName">控制器名称</param>
        /// <param name="sActionName">Action名称</param>
        /// <param name="iMenuId">菜单Id</param>
        /// <returns></returns>
        Task<bool> CheckMenuControllerNameActionNameAsync(string sAreaName, string sControllerName, string sActionName, int iMenuId);
        /// <summary>
        /// 检查用户菜单权限
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="iMenuId">菜单ID</param>
        /// <returns></returns>
        Task<bool> CheckUserMenuPowerAsync(int iUserId, int iMenuId);

        List<Menu> SelectALL(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        Menu Select(int id, string sOperator = null);
        Menu Select(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityMenu">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<Menu>> SelectALLAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<Menu> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityMenu">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<Menu> SelectAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        Task<int> AppendAsync(Menu entityMenu, string sOperator);
        int Append(Menu entityMenu, string sOperator);
    }
}