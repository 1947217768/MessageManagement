using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Roles;
using Message.IRepository;
using Message.IService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Service
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _RolesRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleMenuRepository _roleMenuRepository;

        private readonly IMapper _Mapper;
        public RolesService(IRolesRepository RolesRepository, IUserRoleRepository userRoleRepository, IRoleMenuRepository roleMenuRepository, IMapper mapper)
        {
            _RolesRepository = RolesRepository;
            _userRoleRepository = userRoleRepository;
            _roleMenuRepository = roleMenuRepository;
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
                await _RolesRepository.InsertAsync(entityRoles, sOperctor);
            }
            else
            {
                entityRoles = await _RolesRepository.SelectAsync(model.Id);
                entityRoles = _Mapper.Map(model, entityRoles);
                _RolesRepository.Update(entityRoles, sOperctor);
            }
            await _userRoleRepository.AddOrDeleteRoleUserAsync(entityRoles.Id, model.lstUserId, sOperctor);
            await _roleMenuRepository.AddOrDeleteRoleMenuAsync(entityRoles.Id, model.lstMenuId, sOperctor);
            return entityRoles;

        }

        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_RolesRepository.DeleteRange(arrId, sOperator) > 0)
            {
                if (arrId?.Length > 0)
                {
                    foreach (int id in arrId)
                    {
                        _roleMenuRepository.Delete(new RoleMenu() { IroleId = id }, sOperator);
                        _userRoleRepository.Delete(new UserRole() { IroleId = id }, sOperator);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
