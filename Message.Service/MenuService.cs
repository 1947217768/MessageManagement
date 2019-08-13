using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Menu;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IRoleMenuRepository _roleMenuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IRoleMenuRepository roleMenuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
            _mapper = mapper;
        }
        public PageInfo<Menu> GetPageList(PageInfo<Menu> pageInfo, Menu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _menuRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<Menu>> GetRoleMenuListAnyncAsync(List<RoleMenu> lstRoleMenu, string sOperator = null)
        {
            List<Menu> lstMenu = new List<Menu>();
            if (lstRoleMenu.Count > 0)
            {
                foreach (RoleMenu entityRoleMenu in lstRoleMenu)
                {
                    Menu entityMenu = await _menuRepository.SelectAsync(entityRoleMenu.ImenuId);
                    if (entityMenu != null)
                    {
                        if (entityMenu.Bdisplay.Value == false)
                        {
                            lstMenu.Add(entityMenu);
                        }
                    }
                }
            }
            return lstMenu;
        }

        public async Task<Menu> AddOrModifyMenuAsync(AddOrModifyMenu model, string sOperator)
        {
            Menu entityMenu;
            if (model.Id == 0)
            {
                entityMenu = _mapper.Map<Menu>(model);

                _menuRepository.Insert(entityMenu, sOperator);
            }
            else
            {
                entityMenu = _menuRepository.Select(model.Id);
                if (entityMenu != null)
                {
                    _mapper.Map(model, entityMenu);
                    _menuRepository.Update(entityMenu, sOperator);
                }
            }
            //添加菜单角色
            if (model.lstRoleId?.Count > 0 && entityMenu.Id > 0)
            {
                await _roleMenuRepository.AddOrDeleteMenuRoleAsync(entityMenu.Id, model.lstRoleId, sOperator);
            }
            return entityMenu;
        }

        public async Task<Menu> ChangeMenuStateAsync(ChangeMenuState model, string sOperator)
        {
            Menu entityMenu = new Menu();
            if (model.Id > 0)
            {
                entityMenu = await _menuRepository.SelectAsync(model.Id);
                if (entityMenu != null)
                {
                    entityMenu = _mapper.Map(model, entityMenu);
                    _menuRepository.Update(entityMenu, sOperator);
                }
            }
            return entityMenu;
        }
        public async Task<List<Menu>> GetMenuListAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _menuRepository.SelectALLAsync(entityMenu, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_menuRepository.DeleteRange(arrId, sOperator) > 0)
            {
                if (arrId?.Length > 0)
                {
                    foreach (int id in arrId)
                    {

                        _roleMenuRepository.DeleteRange(_roleMenuRepository.SelectALL(new RoleMenu() { ImenuId = id }), sOperator);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
