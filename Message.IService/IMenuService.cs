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
        /// 根据角色菜单对应关系获得菜单
        /// </summary>
        /// <param name="lstRoleMenu">角色菜单对应关系</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>菜单集合</returns>
        Task<List<Menu>> GetRoleMenuListAnyncAsync(List<RoleMenu> lstRoleMenu, string sOperator = null);
        /// <summary>
        /// 获取父级菜单列表
        /// </summary>
        /// <returns></returns>
        //List<Menu> GetParentMenuList();

        Task<Menu> AddOrModifyMenuAsync(AddOrModifyMenu model, string sOperator);

        Task<Menu> ChangeMenuStateAsync(ChangeMenuState model, string sOperator);

        Task<List<Menu>> GetMenuListAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);
    }
}