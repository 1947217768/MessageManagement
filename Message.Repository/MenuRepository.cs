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
    public partial class MenuRepository : MessageManagementDBRepository<Menu>, IMenuRepository
    {
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
        public override bool BeforeAppend(DbContext DB, Menu entity, string sOperator)
        {
            return base.BeforeAppend(DB, entity, sOperator);
        }
        public override void AfterAppend(DbContext DB, Menu entity, string sOperator)
        {
            entity.SlinkUrl += "?id=" + entity.Id;
            Update(entity, sOperator);
            base.AfterAppend(DB, entity, sOperator);
        }
        public override void ChangeDataDeleteKey(Menu entity, string sOperator)
        {
            string[] sUserMenuKey = RedisHelper.Keys("*_UserMenu");
            string[] sUseTreeItemMenuKey = RedisHelper.Keys("*_UserTreeItemMenu");
            RedisHelper.Del(sUserMenuKey);
            RedisHelper.Del(sUseTreeItemMenuKey);
            base.ChangeDataDeleteKey(entity, sOperator);
        }
    }
}
