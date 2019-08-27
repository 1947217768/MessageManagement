using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.Repository
{
    public partial class RolesRepository : MessageManagementDBRepository<Roles>, IRolesRepository
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleMenuRepository _roleMenuRepository;
        public RolesRepository(IUserRoleRepository userRoleRepository, IRoleMenuRepository roleMenuRepository)
        {
            _userRoleRepository = userRoleRepository;
            _roleMenuRepository = roleMenuRepository;
        }
        protected override IQueryable<Roles> ExistsFilter(out string sErrorMessage, Roles entity, IQueryable<Roles> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.SroleName == entity.SroleName);
            sErrorMessage = $"[{entity.SroleName}]已经存在!";
            return query;
        }
        protected override IQueryable<Roles> OrderBy(IQueryable<Roles> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override void ChangeDataDeleteKey(Roles entity, string sOperator)
        {
            string sRolesKey = "System_Roles";
            if (RedisHelper.Exists(sRolesKey))
            {
                RedisHelper.Del(sRolesKey);
            }
            base.ChangeDataDeleteKey(entity, sOperator);
        }
        public override void AfterDelete(DbContext DB, Roles entity, string sOperator)
        {
            _roleMenuRepository.DeleteRange(_roleMenuRepository.SelectALL(new RoleMenu() { IroleId = entity.Id }), sOperator);
            _userRoleRepository.DeleteRange(_userRoleRepository.SelectALL(new UserRole() { IroleId = entity.Id }), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
    }
}
