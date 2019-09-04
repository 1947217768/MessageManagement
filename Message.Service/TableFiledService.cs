using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.TableFiled;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Service
{
    public class TableFiledService : ITableFiledService
    {
        private readonly ITableFiledRepository _tableFiledRepository;
        private readonly IDataTableService _dataTableService;

        private readonly IDataTypeService _dataTypeService;
        private readonly IMapper _mapper;

        public TableFiledService(ITableFiledRepository TableFiledRepository, IDataTableService dataTableService, IDataTypeService dataTypeService, IMapper mapper)
        {
            _tableFiledRepository = TableFiledRepository;
            _dataTableService = dataTableService;
            _dataTypeService = dataTypeService;
            _mapper = mapper;
        }
        public PageInfo<ViewTableFiled> GetPageList(PageInfo<ViewTableFiled> pageInfo, ViewTableFiled oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            if (!string.IsNullOrWhiteSpace(oSearchEntity.StableName) || !string.IsNullOrWhiteSpace(oSearchEntity.StypeName))
            {
                DataTable entityDataTable = _dataTableService.Select(new DataTable() { StableName = oSearchEntity.StableName });
                if (entityDataTable != null)
                {
                    oSearchEntity.IdataTableId = entityDataTable.Id;
                }
                DataType entityDataType = _dataTypeService.Select(new DataType() { StypeName = oSearchEntity.StypeName });
                if (entityDataType != null)
                {
                    oSearchEntity.IdataTypeId = entityDataType.Id;
                }
                pageInfo = _mapper.Map<PageInfo<ViewTableFiled>>(_tableFiledRepository.GetPageList(_mapper.Map<PageInfo<TableFiled>>(pageInfo), _mapper.Map<TableFiled>(oSearchEntity), sOperator, iOrderGroup, sSortName, sSortOrder));
            }
            else
            {
                pageInfo = _mapper.Map<PageInfo<ViewTableFiled>>(_tableFiledRepository.GetPageList(_mapper.Map<PageInfo<TableFiled>>(pageInfo), _mapper.Map<TableFiled>(oSearchEntity), sOperator, iOrderGroup, sSortName, sSortOrder));
            }
            if (pageInfo.data.Any())
            {
                foreach (ViewTableFiled entityViewTableFiled in pageInfo.data)
                {
                    DataType entityDataType = _dataTypeService.Select(entityViewTableFiled.IdataTypeId);
                    DataTable entityDataTable = _dataTableService.Select(entityViewTableFiled.IdataTableId);
                    if (entityDataType != null)
                    {
                        entityViewTableFiled.StypeName = entityDataType.StypeName;
                    }
                    if (entityDataTable != null)
                    {
                        entityViewTableFiled.StableName = entityDataTable.StableName;
                    }
                }
            }
            return pageInfo;
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_tableFiledRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<TableFiled> SelectALL(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _tableFiledRepository.SelectALL(entityTableFiled, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public TableFiled Select(int id, string sOperator = null)
        {
            return _tableFiledRepository.Select(id, sOperator);
        }

        public TableFiled Select(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _tableFiledRepository.Select(entityTableFiled, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<TableFiled>> SelectALLAsync(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _tableFiledRepository.SelectALLAsync(entityTableFiled, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<TableFiled> SelectAsync(int id, string sOperator = null)
        {
            return await _tableFiledRepository.SelectAsync(id, sOperator);
        }

        public async Task<TableFiled> SelectAsync(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _tableFiledRepository.SelectAsync(entityTableFiled, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(TableFiled entityTableFiled, string sOperator)
        {
            return await _tableFiledRepository.AppendAsync(entityTableFiled, sOperator);
        }
        public int Append(TableFiled entityTableFiled, string sOperator)
        {
            return _tableFiledRepository.Append(entityTableFiled, sOperator);
        }

        public async Task<TableFiled> AddOrModifyTableFiledAsync(TableFiled model, string sOperator)
        {
            TableFiled entityTableFiled;
            if (model.Id == 0)
            {
                entityTableFiled = _mapper.Map<TableFiled>(model);
                await _tableFiledRepository.AppendAsync(entityTableFiled, sOperator);
            }
            else
            {
                entityTableFiled = await _tableFiledRepository.SelectAsync(model.Id);
                if (entityTableFiled != null)
                {
                    //_mapper.Map(model, entityTableFiled);
                    entityTableFiled.IdataTableId = model.IdataTableId;
                    entityTableFiled.IdataTypeId = model.IdataTypeId;
                    entityTableFiled.ImaxLength = model.ImaxLength;
                    entityTableFiled.SfiledName = model.SfiledName;
                    entityTableFiled.BisEmpty = model.BisEmpty;
                    entityTableFiled.Sremarks = model.Sremarks;
                    entityTableFiled.Sexplain = model.Sexplain;
                    _tableFiledRepository.Update(entityTableFiled, sOperator);
                }
            }
            return entityTableFiled;
        }

        public async Task<List<ViewTableFiled>> GetViewTableInfoAsync(int iTableId = 0)
        {
            List<TableFiled> lstTableFiled = new List<TableFiled>();
            List<ViewTableFiled> lstViewTableFiled = new List<ViewTableFiled>();
            if (iTableId > 0)
            {
                lstTableFiled = await _tableFiledRepository.SelectALLAsync(new TableFiled() { IdataTableId = iTableId });
            }
            else
            {
                lstTableFiled = await _tableFiledRepository.SelectALLAsync();
            }
            lstViewTableFiled = _mapper.Map<List<ViewTableFiled>>(lstTableFiled);
            foreach (ViewTableFiled entityTableFiled in lstViewTableFiled)
            {
                DataType entityDataType = await _dataTypeService.SelectAsync(entityTableFiled.IdataTypeId);
                DataTable entityDataTable = await _dataTableService.SelectAsync(entityTableFiled.IdataTableId);
                if (entityDataType != null)
                {
                    entityTableFiled.StypeName = entityDataType.StypeName;
                }
                if (entityDataTable != null)
                {
                    entityTableFiled.StableName = entityDataTable.StableName;
                }
            }
            return lstViewTableFiled;
        }
    }
}
