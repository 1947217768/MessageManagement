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
    public class RoleMenuService : IRoleMenuService
    {
        private readonly IRoleMenuRepository _RoleMenuRepository;
        public RoleMenuService(IRoleMenuRepository RoleMenuRepository)
        {
            _RoleMenuRepository = RoleMenuRepository;
        }
        public PageInfo<RoleMenu> GetPageList(PageInfo<RoleMenu> pageInfo, RoleMenu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RoleMenuRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<RoleMenu>> GetRoleMenuListAsync(RoleMenu entityRoleMenu, string sOperator = null)
        {
            if (entityRoleMenu != null)
            {
                List<RoleMenu> lstMenu = await _RoleMenuRepository.SelectALLAsync(entityRoleMenu, sOperator);
                return lstMenu;
            }
            return null;
        }
        public async Task<List<RoleMenu>> AddOrDeleteMenuRoleAsync(int iMneuId, List<int> lstRoleId, string sOperator)
        {
            List<RoleMenu> lstRoleMenu = new List<RoleMenu>();
            if (iMneuId > 0)
            {
                //根据获取菜单Id获取角色列表
                lstRoleMenu = await _RoleMenuRepository.SelectALLAsync(new RoleMenu() { ImenuId = iMneuId });
                if (lstRoleMenu?.Count > 0)
                {
                    List<int> lstOldUserRoleId = lstRoleMenu.Select(x => x.IroleId).ToList();
                    List<int> lstNewRoleMenuId = new List<int>();
                    if (!lstOldUserRoleId.Equals(lstRoleId))
                    {
                        if (lstOldUserRoleId.Count > lstRoleId.Count)
                        {
                            lstNewRoleMenuId = lstOldUserRoleId.Except(lstRoleId).ToList();
                        }
                        else
                        {
                            lstNewRoleMenuId = lstRoleId.Except(lstOldUserRoleId).ToList();
                        }
                        if (lstNewRoleMenuId?.Count > 0)
                        {
                            foreach (int iRoleId in lstNewRoleMenuId)
                            {
                                RoleMenu entityRoleMenu = await _RoleMenuRepository.SelectAsync(new RoleMenu() { ImenuId = iMneuId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await _RoleMenuRepository.AppendAsync(new RoleMenu() { ImenuId = iMneuId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    _RoleMenuRepository.Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstRoleMenu = await _RoleMenuRepository.SelectALLAsync(new RoleMenu() { ImenuId = iMneuId });
                        }
                    }
                }
                else
                {
                    if (lstRoleId?.Count > 0)
                    {
                        foreach (int iRoleId in lstRoleId)
                        {
                            await _RoleMenuRepository.AppendAsync(new RoleMenu() { ImenuId = iMneuId, IroleId = iRoleId }, sOperator);
                        }
                        lstRoleMenu = await _RoleMenuRepository.SelectALLAsync(new RoleMenu() { ImenuId = iMneuId });
                    }
                }
            }
            return lstRoleMenu;
        }
        public async Task<List<RoleMenu>> AddOrDeleteRoleMenuAsync(int iRoleId, List<int> lstMenuId, string sOperator)
        {
            List<RoleMenu> lstRoleMenu = new List<RoleMenu>();
            if (iRoleId > 0)
            {

                //根据获取角色Id获取角色列表
                lstRoleMenu = await _RoleMenuRepository.SelectALLAsync(new RoleMenu() { IroleId = iRoleId });
                if (lstRoleMenu?.Count > 0)
                {
                    List<int> lstOldUserRoleId = lstRoleMenu.Select(x => x.ImenuId).ToList();
                    List<int> lstNewRoleMenuId = new List<int>();
                    if (!lstOldUserRoleId.Equals(lstMenuId))
                    {
                        if (lstOldUserRoleId.Count > lstMenuId.Count)
                        {
                            lstNewRoleMenuId = lstOldUserRoleId.Except(lstMenuId).ToList();
                        }
                        else
                        {
                            lstNewRoleMenuId = lstMenuId.Except(lstOldUserRoleId).ToList();
                        }
                        if (lstNewRoleMenuId?.Count > 0)
                        {
                            foreach (int iMenuId in lstNewRoleMenuId)
                            {
                                RoleMenu entityRoleMenu = await _RoleMenuRepository.SelectAsync(new RoleMenu() { ImenuId = iMenuId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await _RoleMenuRepository.AppendAsync(new RoleMenu() { ImenuId = iMenuId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    _RoleMenuRepository.Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstRoleMenu = await _RoleMenuRepository.SelectALLAsync(new RoleMenu() { IroleId = iRoleId });
                        }
                    }
                }
                else
                {
                    foreach (int iMenuId in lstMenuId)
                    {
                        await _RoleMenuRepository.AppendAsync(new RoleMenu() { ImenuId = iMenuId, IroleId = iRoleId }, sOperator);
                    }
                    lstRoleMenu = await _RoleMenuRepository.SelectALLAsync(new RoleMenu() { IroleId = iRoleId });
                }
            }
            return lstRoleMenu;
        }

        public List<RoleMenu> SelectALL(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RoleMenuRepository.SelectALL(entityRoleMenu, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public RoleMenu Select(int id, string sOperator = null)
        {
            return _RoleMenuRepository.Select(id, sOperator);
        }

        public RoleMenu Select(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RoleMenuRepository.Select(entityRoleMenu, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public Task<List<RoleMenu>> SelectALLAsync(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RoleMenuRepository.SelectALLAsync(entityRoleMenu, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public Task<RoleMenu> SelectAsync(int id, string sOperator = null)
        {
            return _RoleMenuRepository.SelectAsync(id, sOperator);
        }

        public Task<RoleMenu> SelectAsync(RoleMenu entityRoleMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RoleMenuRepository.SelectAsync(entityRoleMenu, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
    }
}
