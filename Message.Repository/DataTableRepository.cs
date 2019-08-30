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
    public partial class DataTableRepository : MessageManagementDBRepository<DataTable>, IDataTableRepository
    {
        private readonly ITableFiledRepository _tableFiledRepository;
        public DataTableRepository(ITableFiledRepository tableFiledRepository)
        {
            _tableFiledRepository = tableFiledRepository;
        }
        protected override IQueryable<DataTable> ExistsFilter(out string sErrorMessage, DataTable entity, IQueryable<DataTable> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.IdataBaseId == entity.IdataBaseId && x.StableName == entity.StableName);
            sErrorMessage = $"此数据库中[{entity.StableName}]已经存在!";
            return query;
        }
        protected override IQueryable<DataTable> OrderBy(IQueryable<DataTable> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override void AfterDelete(DbContext DB, DataTable entity, string sOperator)
        {
            _tableFiledRepository.DeleteRange(_tableFiledRepository.SelectALL(new TableFiled() { IdataTableId = entity.Id }), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
    }
}
