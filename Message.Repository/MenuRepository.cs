using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.Entity.Redis;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.Repository
{
    public partial class MenuRepository : MessageManagementDBRepository<Menu>, IMenuRepository
    {
        private readonly IRoleMenuRepository _roleMenuRepository;
        private readonly IMenuActionRepository _menuActionRepository;
        public MenuRepository(IRoleMenuRepository roleMenuRepository, IMenuActionRepository menuActionRepository)
        {
            _roleMenuRepository = roleMenuRepository;
            _menuActionRepository = menuActionRepository;
        }
        protected override IQueryable<Menu> ExistsFilter(out string sErrorMessage, Menu entity, IQueryable<Menu> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.Sname == entity.Sname);
            sErrorMessage = $"[{entity.Sname}]已经存在!";
            return query;
        }
        protected override IQueryable<Menu> OrderBy(IQueryable<Menu> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override void AfterAppend(DbContext DB, Menu entity, string sOperator)
        {
            entity.SlinkUrl += "?id=" + entity.Id;
            Update(entity, sOperator);
            base.AfterAppend(DB, entity, sOperator);
        }
        public override void AfterDelete(DbContext DB, Menu entity, string sOperator)
        {
            _roleMenuRepository.DeleteRange(_roleMenuRepository.SelectALL(new RoleMenu() { ImenuId = entity.Id }), sOperator);
            _menuActionRepository.DeleteRange(_menuActionRepository.SelectALL(new MenuAction() { ImenuId = entity.Id }), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
        public override void ChangeDataDeleteKey(Menu entity, string sOperator)
        {
            //删除用户树菜单
            RedisMethod.DeleteUserTreeMenu();
            RedisMethod.DeleteUserMenu();
            base.ChangeDataDeleteKey(entity, sOperator);
        }
    }
}
