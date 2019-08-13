using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IRepository;
using Message.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        public UserRoleService(IUserRoleRepository UserRoleRepository)
        {
            _UserRoleRepository = UserRoleRepository;
        }

        public PageInfo<UserRole> GetPageList(PageInfo<UserRole> pageInfo, UserRole oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _UserRoleRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public List<UserRole> GetRoleList(UserRole entityUserRole = null)
        {
            return _UserRoleRepository.SelectALL(entityUserRole);
        }
        public async Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null)
        {
            return await _UserRoleRepository.SelectALLAsync(entityUserRole);
        }
        public async Task<List<UserRole>> GetRoleListAsync(UserRole entityUserRole = null, string sOperator = null)
        {
            return await _UserRoleRepository.SelectALLAsync(entityUserRole, sOperator);
        }
    }
}
