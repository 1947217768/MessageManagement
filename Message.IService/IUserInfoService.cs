using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IUserInfoService
    {
        PageInfo<UserInfo> GetPageList(PageInfo<UserInfo> pageInfo, UserInfo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<UserInfo> CheckUserAsync(string sLoginName, string sLoginPwd, string sLoginIp = null);
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <returns></returns>
        Task<List<UserRole>> GetUserRoleListAsync(UserRole entityUserRole, string sSortOrder = null);
        /// <summary>
        /// 新增或修改用户信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <returns></returns>
        Task<UserInfo> AddOrModifyUserInfoAsync(AddOrModifyUserInfo model, string sOperator);
        /// <summary>
        /// 修改用户锁定状态
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<bool> ChangeUserLockStatusAsync(ChangeUserStatus entity, string sOperator);

        Task<UserInfo> GetUserInfoAsync(UserInfo entityUserInfo, string sOperator = null);
        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="entityUserInfo"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        Task<List<UserInfo>> GetUserInfoListAsync(UserInfo entityUserInfo = null, string sOperator = null);
        UserInfo ChangeUserPassWord(UserInfo entity, string sOperator);

        bool DeleteRange(int[] arrUserId, string sOperator);

        UserInfo Select(int id, string sOperator = null);
        UserInfo Select(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityUserInfo">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<UserInfo>> SelectALLAsync(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<UserInfo> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityUserInfo">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<UserInfo> SelectAsync(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

    }
}