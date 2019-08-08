using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Repository
{
    public partial class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        protected override IQueryable<UserRole> ExistsFilter(out string sErrorMessage, UserRole entity, IQueryable<UserRole> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.IroleId == entity.IroleId && x.IuserId == entity.IuserId);
            sErrorMessage = $"此用户已拥有此角色!";
            return query;
        }
        protected override IQueryable<UserRole> OrderBy(IQueryable<UserRole> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public async Task<List<UserRole>> AddOrDeleteRoleUserAsync(int iRoleId, List<int> lstUserId, string sOperator)
        {
            List<UserRole> lstUserRole = new List<UserRole>();
            if (iRoleId > 0)
            {
                //根据获取角色Id获取用户列表
                lstUserRole = await SelectALLAsync(new UserRole() { IroleId = iRoleId });
                if (lstUserRole?.Count > 0)
                {
                    List<int> lstOldUserRoleId = lstUserRole.Select(x => x.IuserId).ToList();
                    List<int> lstNewUserRoleId = new List<int>();
                    if (!lstOldUserRoleId.Equals(lstUserId))
                    {
                        if (lstOldUserRoleId.Count > lstUserId.Count)
                        {
                            lstNewUserRoleId = lstOldUserRoleId.Except(lstUserId).ToList();
                        }
                        else
                        {
                            lstNewUserRoleId = lstUserId.Except(lstOldUserRoleId).ToList();
                        }
                        if (lstNewUserRoleId?.Count > 0)
                        {
                            foreach (int iUserId in lstNewUserRoleId)
                            {
                                UserRole entityRoleMenu = await SelectAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await InsertAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstUserRole = await SelectALLAsync(new UserRole() { IroleId = iRoleId });
                        }
                    }
                }
                else
                {
                    if (lstUserId?.Count > 0)
                    {
                        foreach (int iUserId in lstUserId)
                        {
                            await InsertAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                        }
                        lstUserRole = await SelectALLAsync(new UserRole() { IroleId = iRoleId });
                    }
                }
            }
            return lstUserRole;
        }

        public async Task<List<UserRole>> AddOrDeleteUserRoleAsync(int iUserId, List<int> lstRoleId, string sOperator)
        {
            List<UserRole> lstUserRole = new List<UserRole>();
            if (iUserId > 0)
            {
                //根据获取用户Id获取角色列表
                lstUserRole = await SelectALLAsync(new UserRole() { IuserId = iUserId });
                if (lstUserRole?.Count > 0)
                {
                    List<int> lstOldUserRoleId = lstUserRole.Select(x => x.IroleId).ToList();
                    List<int> lstNewUserRoleId = new List<int>();
                    if (!lstOldUserRoleId.Equals(lstRoleId))
                    {
                        if (lstOldUserRoleId.Count > lstRoleId.Count)
                        {
                            lstNewUserRoleId = lstOldUserRoleId.Except(lstRoleId).ToList();
                        }
                        else
                        {
                            lstNewUserRoleId = lstRoleId.Except(lstOldUserRoleId).ToList();
                        }
                        if (lstNewUserRoleId?.Count > 0)
                        {
                            foreach (int iRoleId in lstNewUserRoleId)
                            {
                                UserRole entityRoleMenu = await SelectAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await InsertAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstUserRole = await SelectALLAsync(new UserRole() { IuserId = iUserId });
                        }
                    }
                }
                else
                {
                    if (lstRoleId?.Count > 0)
                    {
                        foreach (int iRoleId in lstRoleId)
                        {
                            await InsertAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                        }
                        lstUserRole = await SelectALLAsync(new UserRole() { IuserId = iUserId });
                    }
                }
            }
            return lstUserRole;
        }

    }
}
