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
    public partial class SystemControllerRepository : MessageManagementDBRepository<SystemController>, ISystemControllerRepository
    {

        private readonly ISystemActionRepository _systemActionRepository;
        public SystemControllerRepository(ISystemActionRepository systemActionRepository)
        {
            _systemActionRepository = systemActionRepository;
        }
        protected override IQueryable<SystemController> ExistsFilter(out string sErrorMessage, SystemController entity, IQueryable<SystemController> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.ScontrollerName == entity.ScontrollerName);
            sErrorMessage = $"[{entity.ScontrollerName}]已经存在!";
            return query;
        }
        protected override IQueryable<SystemController> OrderBy(IQueryable<SystemController> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override bool BeforeAppend(DbContext DB, SystemController entity, string sOperator)
        {
            return base.BeforeAppend(DB, entity, sOperator);
        }
        public override void AfterDelete(DbContext DB, SystemController entity, string sOperator)
        {
            _systemActionRepository.DeleteRange(_systemActionRepository.SelectALL(new SystemAction() { IcontrollerId = entity.Id }), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
    }
}
