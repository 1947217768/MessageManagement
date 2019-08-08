using Message.Core.Models;
using Message.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IUserRoleService
    {
        PageInfo<UserRole> GetPageList(PageInfo<UserRole> pageInfo, UserRole oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 异步获取角色集合
        /// </summary>
        /// <param name="entityUserRole">筛选条件</param>
        /// <returns></returns>
        Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null);
        /// <summary>
        /// 获取角色集合
        /// </summary>
        /// <param name="entityUserRole">筛选条件</param>
        /// <returns></returns>
        List<UserRole> GetRoleList(UserRole entityUserRole = null);
        /// <summary>
        /// 获取用户角色集合
        /// </summary>
        /// <param name="entityUserRole"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null, string sOperator = null);
       //Task<List<UserRole>> AddOrDeleteUserRoleAsync(int iUserId, List<int> lstRoleId, string sOperator);

    }
}