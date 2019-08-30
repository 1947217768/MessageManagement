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
    public class DataBaseService : IDataBaseService
    {
        private readonly IDataBaseRepository _DataBaseRepository;
        private readonly IMapper _mapper;

        public DataBaseService(IDataBaseRepository DataBaseRepository, IMapper mapper)
        {
            _DataBaseRepository = DataBaseRepository;
            _mapper = mapper;
        }
        public PageInfo<DataBase> GetPageList(PageInfo<DataBase> pageInfo, DataBase oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _DataBaseRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_DataBaseRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<DataBase> SelectALL(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _DataBaseRepository.SelectALL(entityDataBase, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public DataBase Select(int id, string sOperator = null)
        {
            return _DataBaseRepository.Select(id, sOperator);
        }

        public DataBase Select(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _DataBaseRepository.Select(entityDataBase, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<DataBase>> SelectALLAsync(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _DataBaseRepository.SelectALLAsync(entityDataBase, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<DataBase> SelectAsync(int id, string sOperator = null)
        {
            return await _DataBaseRepository.SelectAsync(id, sOperator);
        }

        public async Task<DataBase> SelectAsync(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _DataBaseRepository.SelectAsync(entityDataBase, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(DataBase entityDataBase, string sOperator)
        {
            return await _DataBaseRepository.AppendAsync(entityDataBase, sOperator);
        }
        public int Append(DataBase entityDataBase, string sOperator)
        {
            return _DataBaseRepository.Append(entityDataBase, sOperator);
        }

        public async Task<DataBase> AddOrModifyDataBaseAsync(DataBase model, string sOperator)
        {
            DataBase entityDataBase;
            if (model.Id == 0)
            {
                entityDataBase = _mapper.Map<DataBase>(model);
                await _DataBaseRepository.AppendAsync(entityDataBase, sOperator);
            }
            else
            {
                entityDataBase = await _DataBaseRepository.SelectAsync(model.Id);
                if (entityDataBase != null)
                {
                    //_mapper.Map(model, entityDataBase);
                    entityDataBase.SdataBaseName = model.SdataBaseName;
                    _DataBaseRepository.Update(entityDataBase, sOperator);
                }
            }
            return entityDataBase;
        }
    }
}
