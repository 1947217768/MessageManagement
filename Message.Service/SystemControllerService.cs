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
    public class SystemControllerService : ISystemControllerService
    {
        private readonly ISystemControllerRepository _systemControllerRepository;
        public SystemControllerService(ISystemControllerRepository systemControllerRepository)
        {
            _systemControllerRepository = systemControllerRepository;
        }
        public PageInfo<SystemController> GetPageList(PageInfo<SystemController> pageInfo, SystemController oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _systemControllerRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
    }
}
