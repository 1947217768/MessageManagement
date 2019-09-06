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
        public override void AfterAppend(DbContext DB, DataTable entity, string sOperator)
        {
            List<TableFiled> lstTableFiled = new List<TableFiled>() {
                new TableFiled(){ SfiledName="Id",IdataTableId=entity.Id,IdataTypeId=2,Sexplain="主键ID",BisEmpty=false},
                new TableFiled(){ SfiledName="Sremarks",IdataTableId=entity.Id,IdataTypeId=5,Sexplain="备注",ImaxLength=200,BisEmpty=true},
                new TableFiled(){ SfiledName="Screater",IdataTableId=entity.Id,IdataTypeId=5,Sexplain="创建人",ImaxLength=50,BisEmpty=false},
                new TableFiled(){ SfiledName="TcreateTime",IdataTableId=entity.Id,IdataTypeId=6,Sexplain="创建时间",BisEmpty=true},
                new TableFiled(){ SfiledName="Smodifier",IdataTableId=entity.Id,IdataTypeId=5,Sexplain="修改人",ImaxLength=50,BisEmpty=false},
                new TableFiled(){ SfiledName="TmodifyTime",IdataTableId=entity.Id,IdataTypeId=6,Sexplain="修改时间",BisEmpty=true},
            };
            _tableFiledRepository.AppendRange(lstTableFiled, sOperator);
            base.AfterAppend(DB, entity, sOperator);
        }
        public override bool BeforeAppend(DbContext DB, DataTable entity, string sOperator)
        {
            return base.BeforeAppend(DB, entity, sOperator);
        }
    }
}
