using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Menu;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IRoleMenuRepository _roleMenuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IUserRoleRepository userRoleRepository, IRoleMenuRepository roleMenuRepository, IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
            _userRoleRepository = userRoleRepository;
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }
        public PageInfo<Menu> GetPageList(PageInfo<Menu> pageInfo, Menu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _menuRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
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
        public async Task<bool> CheckMenuActionAsync(string sControllerName, string sActionName, int iMenuId)
        {
            Menu entityMenu = await _menuRepository.SelectAsync(iMenuId);
            if (entityMenu != null)
            {
                string[] arrMenu = entityMenu.SlinkUrl.Split('/');
            }
            return false;
        }
        public async Task<bool> CheckUserMenuPowerAsync(int iUserId, int iMenuId)
        {
            UserInfo entityUserInfo = await _userInfoRepository.SelectAsync(iUserId);
            Menu entityMenu = await _menuRepository.SelectAsync(iMenuId);
            if (entityUserInfo != null && entityMenu != null)
            {
                string sUserMenuKey = entityUserInfo.SloginName + "_UserMenu";
                List<Menu> lstUserMenu = new List<Menu>();
                //获取用户菜单
                if (RedisHelper.Exists(sUserMenuKey))
                {
                    lstUserMenu = RedisHelper.Get<List<Menu>>(sUserMenuKey);
                }
                else
                {
                    lstUserMenu = await GetRoleMenuListAnyncAsync(entityUserInfo.Id);
                    RedisHelper.Set(sUserMenuKey, lstUserMenu);
                }
                if (lstUserMenu?.Count > 0)
                {
                    if (lstUserMenu.Any(x => x.Id == entityMenu.Id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public async Task<List<Menu>> GetRoleMenuListAnyncAsync(int iUserId, string sOperator = null)
        {
            List<Menu> lstMenu = new List<Menu>();
            UserInfo entityUserInfo = await _userInfoRepository.SelectAsync(iUserId);
            if (entityUserInfo != null)
            {
                //查询用户拥有角色集合
                List<UserRole> lstUserRoleList = await _userRoleRepository.SelectALLAsync(new UserRole() { IuserId = iUserId });
                List<RoleMenu> lstRoleMenu = new List<RoleMenu>();
                //查询角色所拥有的菜单集合
                if (lstUserRoleList?.Count > 0)
                {
                    foreach (UserRole entityUserRole in lstUserRoleList)
                    {
                        List<RoleMenu> lstRoleMenuList = await _roleMenuRepository.SelectALLAsync(new RoleMenu() { IroleId = entityUserRole.IroleId });
                        if (lstRoleMenuList?.Count > 0)
                        {
                            lstRoleMenu.AddRange(lstRoleMenuList);
                        }
                    }
                    //去重
                    lstRoleMenu = lstRoleMenu.Where((x, i) => lstRoleMenu.FindIndex(z => z.ImenuId == x.ImenuId) == i).ToList();
                    //获取菜单
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
                }
            }
            return lstMenu;
        }
    }
}
