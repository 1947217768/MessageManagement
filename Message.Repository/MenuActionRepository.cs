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
    public partial class MenuActionRepository : MessageManagementDBRepository<MenuAction>, IMenuActionRepository
    {
        protected override IQueryable<MenuAction> ExistsFilter(out string sErrorMessage, MenuAction entity, IQueryable<MenuAction> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.IactionId == entity.IactionId && x.ImenuId == entity.ImenuId);
            sErrorMessage = $"此菜单已拥有此方法!";
            return query;
        }
        protected override IQueryable<MenuAction> OrderBy(IQueryable<MenuAction> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override bool BeforeAppend(DbContext DB, MenuAction entity, string sOperator)
        {
            return base.BeforeAppend(DB, entity, sOperator);
        }
    }
}
