using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.Redis;
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
        private readonly IUserRoleService _userRoleService;
        private readonly IUserInfoService _userInfoService;
        private readonly IRoleMenuService _roleMenuService;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IUserRoleService userRoleService, IRoleMenuService roleMenuService, IUserInfoService userInfoService, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _roleMenuService = roleMenuService;
            _userRoleService = userRoleService;
            _userInfoService = userInfoService;
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
                _menuRepository.Append(entityMenu, sOperator);
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
            await _roleMenuService.AddOrDeleteMenuRoleAsync(entityMenu.Id, model.lstRoleId, sOperator);
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
                    if (entityMenu.Sname == "菜单管理")
                    {
                        throw new System.Exception("此菜单不能隐藏!");
                    }
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
                return true;
            }
            return false;
        }
        public async Task<bool> CheckMenuControllerNameActionNameAsync(string sAreaName, string sControllerName, string sActionName, int iMenuId)
        {
            Menu entityMenu = await _menuRepository.SelectAsync(iMenuId);
            if (entityMenu != null)
            {
                string[] arrMenu = entityMenu.SlinkUrl.Split('?')[0].Split('/');
                if (arrMenu.Length == 4)
                {
                    if (arrMenu[1] == sAreaName && arrMenu[2] == sControllerName && arrMenu[3] == sActionName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public async Task<bool> CheckUserMenuPowerAsync(int iUserId, int iMenuId)
        {
            UserInfo entityUserInfo = await _userInfoService.SelectAsync(iUserId);
            Menu entityMenu = await _menuRepository.SelectAsync(iMenuId);
            if (entityUserInfo != null && entityMenu != null)
            {
                List<Menu> lstUserMenu = await RedisMethod.GetUserMenuAsync(entityUserInfo.Id, -1, () => GetRoleMenuListAsync(iUserId));
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
        public async Task<List<Menu>> GetRoleMenuListAsync(int iUserId, string sOperator = null)
        {
            List<Menu> lstMenu = new List<Menu>();
            UserInfo entityUserInfo = await _userInfoService.SelectAsync(iUserId);
            if (entityUserInfo != null)
            {
                //查询用户拥有角色集合
                List<UserRole> lstUserRoleList = await _userRoleService.SelectALLAsync(new UserRole() { IuserId = iUserId });
                List<RoleMenu> lstRoleMenu = new List<RoleMenu>();
                //查询角色所拥有的菜单集合
                if (lstUserRoleList?.Count > 0)
                {
                    foreach (UserRole entityUserRole in lstUserRoleList)
                    {
                        List<RoleMenu> lstRoleMenuList = await _roleMenuService.SelectALLAsync(new RoleMenu() { IroleId = entityUserRole.IroleId });
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

        public List<Menu> SelectALL(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _menuRepository.SelectALL(entityMenu, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public Menu Select(int id, string sOperator = null)
        {
            return _menuRepository.Select(id, sOperator);
        }

        public Menu Select(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _menuRepository.Select(entityMenu, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<Menu>> SelectALLAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _menuRepository.SelectALLAsync(entityMenu, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<Menu> SelectAsync(int id, string sOperator = null)
        {
            return await _menuRepository.SelectAsync(id, sOperator);
        }

        public async Task<Menu> SelectAsync(Menu entityMenu = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _menuRepository.SelectAsync(entityMenu, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(Menu entityMenu, string sOperator)
        {
            return await _menuRepository.AppendAsync(entityMenu, sOperator);
        }
        public int Append(Menu entityMenu, string sOperator)
        {
            return _menuRepository.Append(entityMenu, sOperator);
        }
    }
}
