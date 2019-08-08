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
    public partial class RoleMenuRepository : BaseRepository<RoleMenu>, IRoleMenuRepository
    {

        protected override IQueryable<RoleMenu> ExistsFilter(out string sErrorMessage, RoleMenu entity, IQueryable<RoleMenu> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.ImenuId == entity.ImenuId && x.IroleId == entity.IroleId);
            sErrorMessage = $"此角色已拥有此菜单!";
            return query;
        }
        protected override IQueryable<RoleMenu> OrderBy(IQueryable<RoleMenu> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }


        public async Task<List<RoleMenu>> AddOrDeleteMenuRoleAsync(int iMneuId, List<int> lstRoleId, string sOperator)
        {
            List<RoleMenu> lstRoleMenu = new List<RoleMenu>();
            if (iMneuId > 0)
            {
                //根据获取菜单Id获取角色列表
                lstRoleMenu = await SelectALLAsync(new RoleMenu() { ImenuId = iMneuId });
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
                                RoleMenu entityRoleMenu = await SelectAsync(new RoleMenu() { ImenuId = iMneuId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await InsertAsync(new RoleMenu() { ImenuId = iMneuId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstRoleMenu = await SelectALLAsync(new RoleMenu() { ImenuId = iMneuId });
                        }
                    }
                }
                else
                {
                    if (lstRoleId?.Count > 0)
                    {
                        foreach (int iRoleId in lstRoleId)
                        {
                            await InsertAsync(new RoleMenu() { ImenuId = iMneuId, IroleId = iRoleId }, sOperator);
                        }
                        lstRoleMenu = await SelectALLAsync(new RoleMenu() { ImenuId = iMneuId });
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
                lstRoleMenu = await SelectALLAsync(new RoleMenu() { IroleId = iRoleId });
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
                                RoleMenu entityRoleMenu = await SelectAsync(new RoleMenu() { ImenuId = iMenuId, IroleId = iRoleId });
                                if (entityRoleMenu == null)
                                {
                                    await InsertAsync(new RoleMenu() { ImenuId = iMenuId, IroleId = iRoleId }, sOperator);
                                }
                                else
                                {
                                    Delete(entityRoleMenu, sOperator);
                                }
                            }
                            lstRoleMenu = await SelectALLAsync(new RoleMenu() { IroleId = iRoleId });
                        }
                    }
                }
                else
                {
                    foreach (int iMenuId in lstMenuId)
                    {
                        await InsertAsync(new RoleMenu() { ImenuId = iMenuId, IroleId = iRoleId }, sOperator);
                    }
                    lstRoleMenu = await SelectALLAsync(new RoleMenu() { IroleId = iRoleId });
                }
            }
            return lstRoleMenu;
        }
        public override void ChangeDataDeleteKey(RoleMenu entity, string sOperator)
        {
            _userRoleRepository.Select(entity.IroleId);
            base.ChangeDataDeleteKey(entity, sOperator);
        }
    }
}
