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
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageInfo">分页信息</param>
        /// <param name="oSearchEntity">查询条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="sSortName">根据字段名称排序</param>
        /// <param name="sSortOrder">排序方式(desc则为倒序)</param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据角色ID删除或添加用户
        /// </summary>
        /// <param name="iRoleId"></param>
        /// <param name="lstUserId"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<UserRole>> AddOrDeleteRoleUserAsync(int iRoleId, List<int> lstUserId, string sOperator);
        /// <summary>
        /// 根据用户ID删除或添加用户角色
        /// </summary>
        /// <param name="iUserId"></param>
        /// <param name="lstRoleId"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<UserRole>> AddOrDeleteUserRoleAsync(int iUserId, List<int> lstRoleId, string sOperator);

        List<UserRole> SelectALL(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        UserRole Select(int id, string sOperator = null);
        UserRole Select(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityUserRole">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<UserRole>> SelectALLAsync(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<UserRole> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityUserRole">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<UserRole> SelectAsync(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="lstTentity"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        int DeleteRange(List<UserRole> lstUserRole, string sOperator);
        int Delete(UserRole entityUserRole, string sOperator);
        int Delete(int Id, string sOperator);

    }
}