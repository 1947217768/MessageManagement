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
    public partial class TableFiledRepository : MessageManagementDBRepository<TableFiled>, ITableFiledRepository
    {
        protected override IQueryable<TableFiled> ExistsFilter(out string sErrorMessage, TableFiled entity, IQueryable<TableFiled> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.SfiledName == entity.SfiledName && x.IdataTableId == entity.IdataTableId);
            sErrorMessage = $"表中[{entity.SfiledName}]已经存在!";
            return query;
        }
        protected override IQueryable<TableFiled> OrderBy(IQueryable<TableFiled> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
    }
}
