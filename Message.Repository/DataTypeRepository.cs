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
    public partial class DataTypeRepository : MessageManagementDBRepository<DataType>, IDataTypeRepository
    {
        protected override IQueryable<DataType> ExistsFilter(out string sErrorMessage, DataType entity, IQueryable<DataType> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.StypeName == entity.StypeName);
            sErrorMessage = $"数据类型[{entity.StypeName}]已经存在!";
            return query;
        }
        protected override IQueryable<DataType> OrderBy(IQueryable<DataType> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
    }
}
