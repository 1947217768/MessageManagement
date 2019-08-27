using Message.Entity.Mapping;
using Message.Entity.ViewEntity;
using Message.Entity.ViewEntity.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Message.Entity.Redis
{
    public class RedisMethod
    {
        public static List<TreeItem<ViewMenu>> GetUserTreeMenu(int iUserId)
        {
            string sUserTreeItemMenuKey = "UserTreeItemMenu_" + iUserId;
            return RedisHelper.Get<List<TreeItem<ViewMenu>>>(sUserTreeItemMenuKey);
        }
        /// <summary>
        /// 用户树菜单缓存壳
        /// </summary>
        /// <param name="iUserId">用户ID(用于区分key)</param>
        /// <param name="iTimeoutSeconds">过期时间，不过期设置为-1</param>
        /// <param name="getData">委托方法(不存在此key执行)</param>
        /// <returns></returns>
        public static async Task<List<TreeItem<ViewMenu>>> GetUserTreeMenuAsync(int iUserId, int iTimeoutSeconds, Func<Task<List<TreeItem<ViewMenu>>>> getData)
        {
            string sUserTreeItemMenuKey = "UserTreeItemMenu_" + iUserId;
            return await RedisHelper.CacheShellAsync(sUserTreeItemMenuKey, iTimeoutSeconds, getData);
        }
        /// <summary>
        /// 删除用户树菜单缓存
        /// </summary>
        /// <param name="iUserId">为0则删除所有</param>
        public static void DeleteUserTreeMenu(int iUserId = 0)
        {
            string sUserTreeItemMenuKey = "UserTreeItemMenu_*";
            if (iUserId > 0)
            {
                sUserTreeItemMenuKey = "UserTreeItemMenu_" + iUserId;
            }
            string[] UserTreeMenuKeys = RedisHelper.Keys(sUserTreeItemMenuKey);
            RedisHelper.Del(UserTreeMenuKeys);
        }
        /// <summary>
        /// 用户菜单缓存壳
        /// </summary>
        /// <param name="iUserId">用户Id</param>
        /// <param name="iTimeoutSeconds">过期时间，不过期设置为-1</param>
        /// <param name="getData">委托方法(不存在此key执行)</param>
        /// <returns></returns>
        public static async Task<List<Menu>> GetUserMenuAsync(int iUserId, int iTimeoutSeconds, Func<Task<List<Menu>>> getData)
        {
            string sUserMenuKey = "UserMenu_" + iUserId;
            return await RedisHelper.CacheShellAsync(sUserMenuKey, iTimeoutSeconds, getData);
        }
        public static void DeleteUserMenu(int iUserId = 0)
        {
            string sUserMenuKey = "UserMenu_*";
            if (iUserId > 0)
            {
                sUserMenuKey = "UserMenu_" + iUserId;
            }
            string[] UserTreeMenuKeys = RedisHelper.Keys(sUserMenuKey);
            RedisHelper.Del(UserTreeMenuKeys);
        }

        public static List<Roles> GetSystemRoles(int iTimeoutSeconds, Func<List<Roles>> getData)
        {
            string sRoleKey = "System_Roles";
            return RedisHelper.CacheShell(sRoleKey, iTimeoutSeconds, getData);
        }
        public static void DeleteSystemRoles()
        {
            string sRoleKey = "System_Roles";
            RedisHelper.Del(sRoleKey);
        }
    }
}
