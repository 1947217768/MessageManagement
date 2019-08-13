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
        Task<List<Menu>> GetRoleMenuListAnyncAsync(int iUserId, string sOperator = null);
        /// <summary>
        /// 获取父级菜单列表
        /// </summary>
        /// <returns></returns>
        //List<Menu> GetParentMenuList();

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
        Task<bool> CheckMenuActionAsync(string sControllerName, string sActionName, int iMenuId);
        /// <summary>
        /// 检查用户菜单权限
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="iMenuId">菜单ID</param>
        /// <returns></returns>
        Task<bool> CheckUserMenuPowerAsync(int iUserId, int iMenuId);
    }
}