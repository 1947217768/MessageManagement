using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
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
    public class DataTypeService : IDataTypeService
    {
        private readonly IDataTypeRepository _DataTypeRepository;
        private readonly IMapper _mapper;

        public DataTypeService(IDataTypeRepository DataTypeRepository, IMapper mapper)
        {
            _DataTypeRepository = DataTypeRepository;
            _mapper = mapper;
        }
        public PageInfo<DataType> GetPageList(PageInfo<DataType> pageInfo, DataType oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _DataTypeRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_DataTypeRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<DataType> SelectALL(DataType entityDataType = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _DataTypeRepository.SelectALL(entityDataType, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public DataType Select(int id, string sOperator = null)
        {
            return _DataTypeRepository.Select(id, sOperator);
        }

        public DataType Select(DataType entityDataType = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _DataTypeRepository.Select(entityDataType, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<DataType>> SelectALLAsync(DataType entityDataType = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _DataTypeRepository.SelectALLAsync(entityDataType, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<DataType> SelectAsync(int id, string sOperator = null)
        {
            return await _DataTypeRepository.SelectAsync(id, sOperator);
        }

        public async Task<DataType> SelectAsync(DataType entityDataType = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _DataTypeRepository.SelectAsync(entityDataType, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(DataType entityDataType, string sOperator)
        {
            return await _DataTypeRepository.AppendAsync(entityDataType, sOperator);
        }
        public int Append(DataType entityDataType, string sOperator)
        {
            return _DataTypeRepository.Append(entityDataType, sOperator);
        }

        public async Task<DataType> AddOrModifyDataTypeAsync(DataType model, string sOperator)
        {
            DataType entityDataType;
            if (model.Id == 0)
            {
                entityDataType = _mapper.Map<DataType>(model);
                await _DataTypeRepository.AppendAsync(entityDataType, sOperator);
            }
            else
            {
                entityDataType = await _DataTypeRepository.SelectAsync(model.Id);
                if (entityDataType != null)
                {
                    //_mapper.Map(model, entityDataType);
                    entityDataType.StypeName = model.StypeName;
                    _DataTypeRepository.Update(entityDataType, sOperator);
                }
            }
            return entityDataType;
        }
    }
}
