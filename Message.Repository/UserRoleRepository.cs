﻿using Message.Core.Models;
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
    public partial class UserRoleRepository : MessageManagementDBRepository<UserRole>, IUserRoleRepository
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
        public override void ChangeDataDeleteKey(UserRole entity, string sOperator)
        {
            string sUserMenuKey = "UserMenu_" + entity.IuserId;
            if (RedisHelper.Exists(sUserMenuKey))
            {
                RedisHelper.Del(sUserMenuKey);
            }
            //用户菜树Redis Key
            string sUserTreeItemMenuKey = "UserTreeItemMenu_" + entity.IuserId;
            if (RedisHelper.Exists(sUserTreeItemMenuKey))
            {
                RedisHelper.Del(sUserTreeItemMenuKey);
            }
            base.ChangeDataDeleteKey(entity, sOperator);
        }
    }
}
