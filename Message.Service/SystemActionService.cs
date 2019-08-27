using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IRepository;
using Message.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
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
    }
}
