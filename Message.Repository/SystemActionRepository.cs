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
    public partial class SystemActionRepository : MessageManagementDBRepository<SystemAction>, ISystemActionRepository
    {

        private readonly IMenuActionRepository _menuActionRepository;
        public SystemActionRepository(IMenuActionRepository menuActionRepository)
        {
            _menuActionRepository = menuActionRepository;
        }
        protected override IQueryable<SystemAction> ExistsFilter(out string sErrorMessage, SystemAction entity, IQueryable<SystemAction> query)
        {
            query = query.Where(x => x.SactionName == entity.SactionName && x.IcontrollerId == entity.IcontrollerId && x.SresultType == entity.SresultType);
            sErrorMessage = "此Action方法已存在";
            return query;
        }
        protected override IQueryable<SystemAction> OrderBy(IQueryable<SystemAction> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override bool BeforeAppend(DbContext DB, SystemAction entity, string sOperator)
        {
            return base.BeforeAppend(DB, entity, sOperator);
        }
        public override void AfterDelete(DbContext DB, SystemAction entity, string sOperator)
        {
            //删除对应关系
            _menuActionRepository.DeleteRange(_menuActionRepository.SelectALL(new MenuAction() { IactionId = entity.Id }), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
    }
}
