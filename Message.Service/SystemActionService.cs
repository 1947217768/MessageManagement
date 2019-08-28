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
    public class SystemActionService : ISystemActionService
    {
        private readonly ISystemActionRepository _systemActionRepository;

        public SystemActionService(ISystemActionRepository systemActionRepository)
        {
            _systemActionRepository = systemActionRepository;
        }
        public PageInfo<SystemAction> GetPageList(PageInfo<SystemAction> pageInfo, SystemAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemActionRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
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
    }
}
