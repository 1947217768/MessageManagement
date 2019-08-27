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
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public PageInfo<UserRole> GetPageList(PageInfo<UserRole> pageInfo, UserRole oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _userRoleRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public List<UserRole> GetRoleList(UserRole entityUserRole = null)
        {
            return _userRoleRepository.SelectALL(entityUserRole);
        }
        public async Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null)
        {
            return await _userRoleRepository.SelectALLAsync(entityUserRole);
        }
        public async Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null, string sOperator = null)
        {
            return await _userRoleRepository.SelectALLAsync(entityUserRole, sOperator);
        }
        public async Task<List<UserRole>> AddOrDeleteRoleUserAsync(int iRoleId, List<int> lstUserId, string sOperator)
        {
            List<UserRole> lstUserRole = new List<UserRole>();
            if (iRoleId > 0)
            {
                //根据获取角色Id获取用户列表
                lstUserRole = await _userRoleRepository.SelectALLAsync(new UserRole() { IroleId = iRoleId });
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
                                UserRole entityRoleMenu = await _userRoleRepository.SelectAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await _userRoleRepository.AppendAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    _userRoleRepository.Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstUserRole = await _userRoleRepository.SelectALLAsync(new UserRole() { IroleId = iRoleId });
                        }
                    }
                }
                else
                {
                    if (lstUserId?.Count > 0)
                    {
                        foreach (int iUserId in lstUserId)
                        {
                            await _userRoleRepository.AppendAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                        }
                        lstUserRole = await _userRoleRepository.SelectALLAsync(new UserRole() { IroleId = iRoleId });
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
                lstUserRole = await _userRoleRepository.SelectALLAsync(new UserRole() { IuserId = iUserId });
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
                                UserRole entityRoleMenu = await _userRoleRepository.SelectAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await _userRoleRepository.AppendAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    _userRoleRepository.Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstUserRole = await _userRoleRepository.SelectALLAsync(new UserRole() { IuserId = iUserId });
                        }
                    }
                }
                else
                {
                    if (lstRoleId?.Count > 0)
                    {
                        foreach (int iRoleId in lstRoleId)
                        {
                            await _userRoleRepository.AppendAsync(new UserRole() { IuserId = iUserId, IroleId = iRoleId }, sOperator);
                        }
                        lstUserRole = await _userRoleRepository.SelectALLAsync(new UserRole() { IuserId = iUserId });
                    }
                }
            }
            return lstUserRole;
        }
        public async Task<List<UserRole>> SelectALLAsync(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _userRoleRepository.SelectALLAsync(entityUserRole, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }
        public async Task<UserRole> SelectAsync(int id, string sOperator = null)
        {
            return await _userRoleRepository.SelectAsync(id, sOperator);
        }
        public async Task<UserRole> SelectAsync(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _userRoleRepository.SelectAsync(entityUserRole, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public int DeleteRange(List<UserRole> lstUserRole, string sOperator)
        {
            return _userRoleRepository.DeleteRange(lstUserRole, sOperator);
        }
        public int Delete(UserRole entityUserRole, string sOperator)
        {
            return _userRoleRepository.Delete(entityUserRole, sOperator);
        }
        public int Delete(int Id, string sOperator)
        {
            return _userRoleRepository.Delete(Id, sOperator);
        }

        public List<UserRole> SelectALL(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _userRoleRepository.SelectALL(entityUserRole, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public UserRole Select(int id, string sOperator = null)
        {
            return _userRoleRepository.Select(id, sOperator);
        }

        public UserRole Select(UserRole entityUserRole = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _userRoleRepository.Select(entityUserRole, sOperator);

        }
    }
}
