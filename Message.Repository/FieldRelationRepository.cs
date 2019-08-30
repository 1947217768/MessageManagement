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
    public partial class FieldRelationRepository : MessageManagementDBRepository<FieldRelation>, IFieldRelationRepository
    {
        protected override IQueryable<FieldRelation> ExistsFilter(out string sErrorMessage, FieldRelation entity, IQueryable<FieldRelation> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.IprimarykeyId == entity.IprimarykeyId && x.IforeignkeyId == entity.IforeignkeyId);
            sErrorMessage = $"已有此外键关系!";
            return query;
        }
        protected override IQueryable<FieldRelation> OrderBy(IQueryable<FieldRelation> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
    }
}
