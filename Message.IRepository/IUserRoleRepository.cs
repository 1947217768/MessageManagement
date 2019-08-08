using Message.Core.Repository;
using Message.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Message.IRepository
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        /// <summary>
        /// 根据角色Id添加用户
        /// </summary>
        /// <param name="iRoleId"></param>
        /// <param name="lstUserId"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<UserRole>> AddOrDeleteRoleUserAsync(int iRoleId, List<int> lstUserId, string sOperator);
        /// <summary>
        /// 根据用户Id添加用户角色
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="lstRoleId"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<UserRole>> AddOrDeleteUserRoleAsync(int iUserId, List<int> lstRoleId, string sOperator);
    }
}
