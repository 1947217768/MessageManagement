using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.SystemAction;
using Message.IRepository;
using Message.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Service
{
    public class SystemActionService : ISystemActionService
    {
        private readonly IMapper _mapper;
        private readonly ISystemActionRepository _systemActionRepository;
        private readonly ISystemControllerService _systemControllerService;

        public SystemActionService(ISystemActionRepository systemActionRepository, ISystemControllerService systemControllerService, IMapper mapper)
        {
            _systemActionRepository = systemActionRepository;
            _systemControllerService = systemControllerService;
            _mapper = mapper;
        }
        public PageInfo<ViewSystemAction> GetPageList(PageInfo<ViewSystemAction> pageInfo, ViewSystemAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            if (!string.IsNullOrWhiteSpace(oSearchEntity.ScontrollerName))
            {
                SystemController entitySystemController = _systemControllerService.Select(new SystemController() { ScontrollerName = oSearchEntity.ScontrollerName });
                if (entitySystemController != null)
                {
                    oSearchEntity.IcontrollerId = entitySystemController.Id;
                    pageInfo = _mapper.Map<PageInfo<ViewSystemAction>>(_systemActionRepository.GetPageList(_mapper.Map<PageInfo<SystemAction>>(pageInfo), _mapper.Map<SystemAction>(oSearchEntity), sOperator, iOrderGroup, sSortName, sSortOrder));
                }
            }
            else
            {
                pageInfo = _mapper.Map<PageInfo<ViewSystemAction>>(_systemActionRepository.GetPageList(_mapper.Map<PageInfo<SystemAction>>(pageInfo), _mapper.Map<SystemAction>(oSearchEntity), sOperator, iOrderGroup, sSortName, sSortOrder));
            }
            if (pageInfo.data.Any())
            {
                foreach (var entity in pageInfo.data)
                {
                    SystemController entitySystemController = _systemControllerService.Select(entity.IcontrollerId);
                    if (entitySystemController != null)
                    {
                        entity.ScontrollerName = entitySystemController.ScontrollerName;
                    }
                }
            }
            return pageInfo;
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_systemActionRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<SystemAction> SelectALL(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemActionRepository.SelectALL(entitySystemAction, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public SystemAction Select(int id, string sOperator = null)
        {
            return _systemActionRepository.Select(id, sOperator);
        }

        public SystemAction Select(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemActionRepository.Select(entitySystemAction, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<SystemAction>> SelectALLAsync(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _systemActionRepository.SelectALLAsync(entitySystemAction, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<SystemAction> SelectAsync(int id, string sOperator = null)
        {
            return await _systemActionRepository.SelectAsync(id, sOperator);
        }

        public async Task<SystemAction> SelectAsync(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _systemActionRepository.SelectAsync(entitySystemAction, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(SystemAction entitySystemAction, string sOperator)
        {
            return await _systemActionRepository.AppendAsync(entitySystemAction, sOperator);
        }
        public int Append(SystemAction entitySystemAction, string sOperator)
        {
            return _systemActionRepository.Append(entitySystemAction, sOperator);
        }

        public async Task<SystemAction> AddOrModifySystemActionAsync(SystemAction model, string sOperator)
        {
            SystemAction entitySystemAction;
            if (model.Id == 0)
            {
                entitySystemAction = model;
                await _systemActionRepository.AppendAsync(entitySystemAction, sOperator);
            }
            else
            {
                entitySystemAction = await _systemActionRepository.SelectAsync(model.Id);
                if (entitySystemAction != null)
                {
                    entitySystemAction.SactionName = model.SactionName;
                    entitySystemAction.IcontrollerId = model.IcontrollerId;
                    entitySystemAction.SresultType = model.SresultType;
                    _systemActionRepository.Update(entitySystemAction, sOperator);
                }
            }
            return entitySystemAction;
        }
    }
}
