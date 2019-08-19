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
    public class MenuActionService : IMenuActionService
    {
        private readonly IMenuActionRepository _MenuActionRepository;
        private readonly ISystemActionRepository _systemActionRepository;

        public MenuActionService(IMenuActionRepository MenuActionRepository, ISystemActionRepository systemActionRepository)
        {
            _MenuActionRepository = MenuActionRepository;
            _systemActionRepository = systemActionRepository;
        }
        public PageInfo<MenuAction> GetPageList(PageInfo<MenuAction> pageInfo, MenuAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _MenuActionRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_MenuActionRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
