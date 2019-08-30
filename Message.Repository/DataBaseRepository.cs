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
    public partial class DataBaseRepository : MessageManagementDBRepository<DataBase>, IDataBaseRepository
    {
        private readonly IDataTableRepository _dataTableRepository;
        public DataBaseRepository(IDataTableRepository dataTableRepository)
        {
            _dataTableRepository = dataTableRepository;
        }

        protected override IQueryable<DataBase> ExistsFilter(out string sErrorMessage, DataBase entity, IQueryable<DataBase> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.SdataBaseName == entity.SdataBaseName);
            sErrorMessage = $"[{entity.SdataBaseName}]已经存在!";
            return query;
        }
        protected override IQueryable<DataBase> OrderBy(IQueryable<DataBase> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override void AfterDelete(DbContext DB, DataBase entity, string sOperator)
        {
            //_dataTableRepository.DeleteRange(_dataTableRepository.SelectALL(new DataTable() { IdataBaseId = entity.Id }), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
    }
}
