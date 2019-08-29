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
    public class SystemControllerService : ISystemControllerService
    {
        private readonly ISystemControllerRepository _systemControllerRepository;
        private readonly IMapper _mapper;

        public SystemControllerService(ISystemControllerRepository systemControllerRepository, IMapper mapper)
        {
            _systemControllerRepository = systemControllerRepository;
            _mapper = mapper;
        }
        public PageInfo<SystemController> GetPageList(PageInfo<SystemController> pageInfo, SystemController oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemControllerRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_systemControllerRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<SystemController> SelectALL(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemControllerRepository.SelectALL(entitySystemController, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public SystemController Select(int id, string sOperator = null)
        {
            return _systemControllerRepository.Select(id, sOperator);
        }

        public SystemController Select(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemControllerRepository.Select(entitySystemController, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<SystemController>> SelectALLAsync(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _systemControllerRepository.SelectALLAsync(entitySystemController, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<SystemController> SelectAsync(int id, string sOperator = null)
        {
            return await _systemControllerRepository.SelectAsync(id, sOperator);
        }

        public async Task<SystemController> SelectAsync(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _systemControllerRepository.SelectAsync(entitySystemController, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(SystemController entitySystemController, string sOperator)
        {
            return await _systemControllerRepository.AppendAsync(entitySystemController, sOperator);
        }
        public int Append(SystemController entitySystemController, string sOperator)
        {
            return _systemControllerRepository.Append(entitySystemController, sOperator);
        }

        public async Task<SystemController> AddOrModifySystemControllerAsync(SystemController model, string sOperator)
        {
            SystemController entitySystemController;
            if (model.Id == 0)
            {
                entitySystemController = _mapper.Map<SystemController>(model);
                await _systemControllerRepository.AppendAsync(entitySystemController, sOperator);
            }
            else
            {
                entitySystemController = await _systemControllerRepository.SelectAsync(model.Id);
                if (entitySystemController != null)
                {
                    //_mapper.Map(model, entitySystemController);
                    entitySystemController.ScontrollerName = model.ScontrollerName;
                    _systemControllerRepository.Update(entitySystemController, sOperator);
                }
            }
            return entitySystemController;
        }
    }
}
