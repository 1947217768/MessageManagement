using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Roles;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.Service
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _RolesRepository;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleMenuService _roleMenuService;

        private readonly IMapper _Mapper;
        public RolesService(IRolesRepository RolesRepository, IUserRoleService userRoleService, IRoleMenuService roleMenuService, IMapper mapper)
        {
            _RolesRepository = RolesRepository;
            _userRoleService = userRoleService;
            _roleMenuService = roleMenuService;
            _Mapper = mapper;
        }
        public PageInfo<Roles> GetPageList(PageInfo<Roles> pageInfo, Roles oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _RolesRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public List<Roles> GetRolesList(Roles entityRoles = null)
        {
            return _RolesRepository.SelectALL(entityRoles);
        }
        public async Task<Roles> AddOrModifyAsync(AddOrModifyRoles model, string sOperctor)
        {
            Roles entityRoles;
            if (model.Id == 0)
            {
                entityRoles = _Mapper.Map<Roles>(model);
                await _RolesRepository.AppendAsync(entityRoles, sOperctor);
            }
            else
            {
                entityRoles = await _RolesRepository.SelectAsync(model.Id);
                entityRoles = _Mapper.Map(model, entityRoles);
                _RolesRepository.Update(entityRoles, sOperctor);
            }
            await _userRoleService.AddOrDeleteRoleUserAsync(entityRoles.Id, model.lstUserId, sOperctor);
            await _roleMenuService.AddOrDeleteRoleMenuAsync(entityRoles.Id, model.lstMenuId, sOperctor);
            return entityRoles;

        }

        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_RolesRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
