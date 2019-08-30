using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.DataTable;
using Message.IRepository;
using Message.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Message.Service
{
    public class DataTableService : IDataTableService
    {
        private readonly IDataTableRepository _dataTableRepository;
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public DataTableService(IDataTableRepository dataTableRepository, IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataTableRepository = dataTableRepository;
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public PageInfo<ViewDataTable> GetPageList(PageInfo<ViewDataTable> pageInfo, ViewDataTable oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            pageInfo = _mapper.Map<PageInfo<ViewDataTable>>(_dataTableRepository.GetPageList(_mapper.Map<PageInfo<DataTable>>(pageInfo), _mapper.Map<DataTable>(oSearchEntity), sOperator, iOrderGroup, sSortName, sSortOrder));
            foreach (ViewDataTable entityViewDataTable in pageInfo.data)
            {
                DataBase entityDataBase = _dataBaseService.Select(entityViewDataTable.IdataBaseId);
                if (entityDataBase != null)
                {
                    entityViewDataTable.SdataBaseName = entityDataBase.SdataBaseName;
                }
            }
            return pageInfo;
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_dataTableRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<DataTable> SelectALL(DataTable entityDataTable = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _dataTableRepository.SelectALL(entityDataTable, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public DataTable Select(int id, string sOperator = null)
        {
            return _dataTableRepository.Select(id, sOperator);
        }

        public DataTable Select(DataTable entityDataTable = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _dataTableRepository.Select(entityDataTable, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<DataTable>> SelectALLAsync(DataTable entityDataTable = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _dataTableRepository.SelectALLAsync(entityDataTable, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<DataTable> SelectAsync(int id, string sOperator = null)
        {
            return await _dataTableRepository.SelectAsync(id, sOperator);
        }

        public async Task<DataTable> SelectAsync(DataTable entityDataTable = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _dataTableRepository.SelectAsync(entityDataTable, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(DataTable entityDataTable, string sOperator)
        {
            return await _dataTableRepository.AppendAsync(entityDataTable, sOperator);
        }
        public int Append(DataTable entityDataTable, string sOperator)
        {
            return _dataTableRepository.Append(entityDataTable, sOperator);
        }

        public async Task<DataTable> AddOrModifyDataTableAsync(DataTable model, string sOperator)
        {
            DataTable entityDataTable;
            if (model.Id == 0)
            {
                entityDataTable = _mapper.Map<DataTable>(model);
                await _dataTableRepository.AppendAsync(entityDataTable, sOperator);
            }
            else
            {
                entityDataTable = await _dataTableRepository.SelectAsync(model.Id);
                if (entityDataTable != null)
                {
                    //_mapper.Map(model, entityDataTable);
                    entityDataTable.IdataBaseId = model.IdataBaseId;
                    entityDataTable.StableName = model.StableName;
                    _dataTableRepository.Update(entityDataTable, sOperator);
                }
            }
            return entityDataTable;
        }
    }
}
