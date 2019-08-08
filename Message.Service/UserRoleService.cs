using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IRepository;
using Message.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        public UserRoleService(IUserRoleRepository UserRoleRepository)
        {
            _UserRoleRepository = UserRoleRepository;
        }

        public PageInfo<UserRole> GetPageList(PageInfo<UserRole> pageInfo, UserRole oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _UserRoleRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public List<UserRole> GetRoleList(UserRole entityUserRole = null)
        {
            return _UserRoleRepository.SelectALL(entityUserRole);
        }
        public async Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null)
        {
            return await _UserRoleRepository.SelectALLAsync(entityUserRole);
        }

        //public async Task<List<UserRole>> AddOrDeleteUserRoleAsync(int iUserId, List<int> lstRoleId, string sOperator)
        //{
        //    List<UserRole> lstUserRole = new List<UserRole>();
        //    if (iUserId > 0 && lstRoleId?.Count > 0)
        //    {
        //        lstUserRole = await _UserRoleRepository.SelectALLAsync(new UserRole() { IuserId = iUserId });
        //        //用户角色集合
        //        //老用户角色对应关系集合
        //        List<int> lstOldUserRoleId = lstUserRole.Select(x => x.IroleId).ToList();
        //        //判断是否相同
        //        if (!lstOldUserRoleId.Equals(lstRoleId))
        //        {
        //            //取差集
        //            List<int> lstNewUserRoleId = new List<int>();
        //            if (lstOldUserRoleId?.Count > lstRoleId?.Count)
        //            {
        //                lstNewUserRoleId = lstOldUserRoleId.Except(lstRoleId).ToList();
        //            }
        //            else
        //            {
        //                lstNewUserRoleId = lstRoleId.Except(lstOldUserRoleId).ToList();
        //            }
        //            foreach (int iRoleId in lstNewUserRoleId)
        //            {
        //                UserRole entityUserRole = await _UserRoleRepository.SelectAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId });
        //                if (entityUserRole == null)
        //                {
        //                    await _UserRoleRepository.InsertAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
        //                }
        //                else
        //                {
        //                    _UserRoleRepository.Delete(entityUserRole, sOperator);
        //                }
        //            }
        //        }
        //    }
        //    lstUserRole = await _UserRoleRepository.SelectALLAsync(new UserRole() { IuserId = iUserId });
        //    return lstUserRole;

        //}
        public async Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null, string sOperator = null)
        {
            return await _UserRoleRepository.SelectALLAsync(entityUserRole, sOperator);
        }
    }
}
