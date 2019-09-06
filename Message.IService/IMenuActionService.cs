using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.MenuAction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IMenuActionService
    {
        PageInfo<ViewMenuAction> GetPageList(PageInfo<ViewMenuAction> pageInfo, ViewMenuAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        bool DeleteRange(int[] arrId, string sOperator);

        List<MenuAction> SelectALL(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);

        MenuAction Select(int id, string sOperator = null);

        MenuAction Select(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<List<MenuAction>> SelectALLAsync(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);

        Task<MenuAction> SelectAsync(int id, string sOperator = null);

        Task<MenuAction> SelectAsync(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<MenuAction> AddOrModifyMenuActionAsync(AddOrModifyMenuAction model, string sOperator);

        Task<int> AppendAsync(MenuAction entityMenuAction, string sOperator);

        int Append(MenuAction entityMenuAction, string sOperator);

        /// <summary>
        /// 检查菜单权限
        /// </summary>
        /// <param name="iMenuId"></param>
        /// <param name="iActionId"></param>
        /// <returns></returns>
        Task<MenuAction> CheckMenuActionPowerAsync(int iMenuId, int iActionId);
    }
}