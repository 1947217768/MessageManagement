using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.MenuAction;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Service
{
    public class MenuActionService : IMenuActionService
    {
        private readonly IMenuActionRepository _menuActionRepository;
        private readonly ISystemActionService _systemActionService;
        private readonly ISystemControllerService _systemControllerService;
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuActionService(IMenuActionRepository menuActionRepository, ISystemActionService systemActionService, ISystemControllerService systemControllerService, IMenuService menuService, IMapper mapper)
        {
            _menuActionRepository = menuActionRepository;
            _systemActionService = systemActionService;
            _systemControllerService = systemControllerService;
            _menuService = menuService;
            _mapper = mapper;
        }
        public PageInfo<ViewMenuAction> GetPageList(PageInfo<ViewMenuAction> pageInfo, ViewMenuAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            if (string.IsNullOrWhiteSpace(oSearchEntity.ScontrollerName))
            {
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SmenuName))
                {
                    Menu entityMenu = _menuService.Select(new Menu() { Sname = oSearchEntity.SmenuName });
                    if (entityMenu != null)
                    {
                        oSearchEntity.ImenuId = entityMenu.Id;
                    }
                }
                pageInfo = _mapper.Map<PageInfo<ViewMenuAction>>(_menuActionRepository.GetPageList(_mapper.Map<PageInfo<MenuAction>>(pageInfo), _mapper.Map<MenuAction>(oSearchEntity), sOperator, iOrderGroup, sSortName, sSortOrder));
            }
            else
            {
                SystemController entitySystemController = _systemControllerService.Select(new SystemController() { ScontrollerName = oSearchEntity.ScontrollerName });
                if (entitySystemController != null)
                {
                    List<SystemAction> lstSystemAction = _systemActionService.SelectALL(new SystemAction() { IcontrollerId = entitySystemController.Id });
                    foreach (SystemAction entitySystemAction in lstSystemAction)
                    {
                        MenuAction entityMenuAction = _menuActionRepository.Select(new MenuAction() { IactionId = entitySystemAction.Id });
                        if (entityMenuAction != null)
                        {
                            List<ViewMenuAction> lstViewMenuAction = new List<ViewMenuAction>();
                            lstViewMenuAction.Add(_mapper.Map<ViewMenuAction>(entityMenuAction));
                            pageInfo.data = lstViewMenuAction;
                            pageInfo.count = lstViewMenuAction.Count;
                        }
                    }
                }
            }
            if (pageInfo.data?.Count > 0)
            {
                foreach (ViewMenuAction entityViewMenuAction in pageInfo.data)
                {
                    Menu entityMenu = _menuService.Select(entityViewMenuAction.ImenuId);
                    if (entityMenu != null)
                    {
                        entityViewMenuAction.SmenuName = entityMenu.Sname;
                    }
                    SystemAction entitySystemAction = _systemActionService.Select(entityViewMenuAction.IactionId);
                    if (entitySystemAction != null)
                    {
                        SystemController entitySystemController = _systemControllerService.Select(entitySystemAction.IcontrollerId);
                        if (entitySystemController != null)
                        {
                            entityViewMenuAction.ScontrollerName = entitySystemController.ScontrollerName;
                            entityViewMenuAction.SactionName = "/" + entitySystemController.ScontrollerName + "/" + entitySystemAction.SactionName + "?iMethodId=" + entitySystemAction.Id;
                        }
                    }
                }
            }
            return pageInfo;
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_menuActionRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<MenuAction> SelectALL(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _menuActionRepository.SelectALL(entityMenuAction, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public MenuAction Select(int id, string sOperator = null)
        {
            return _menuActionRepository.Select(id, sOperator);
        }

        public MenuAction Select(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _menuActionRepository.Select(entityMenuAction, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<MenuAction>> SelectALLAsync(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _menuActionRepository.SelectALLAsync(entityMenuAction, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<MenuAction> SelectAsync(int id, string sOperator = null)
        {
            return await _menuActionRepository.SelectAsync(id, sOperator);
        }

        public async Task<MenuAction> SelectAsync(MenuAction entityMenuAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _menuActionRepository.SelectAsync(entityMenuAction, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(MenuAction entityMenuAction, string sOperator)
        {
            return await _menuActionRepository.AppendAsync(entityMenuAction, sOperator);
        }
        public int Append(MenuAction entityMenuAction, string sOperator)
        {
            return _menuActionRepository.Append(entityMenuAction, sOperator);
        }

        public async Task<MenuAction> AddOrModifyMenuActionAsync(AddOrModifyMenuAction model, string sOperator)
        {
            MenuAction entityMenuAction;
            if (model.Id == 0)
            {
                entityMenuAction = _mapper.Map<MenuAction>(model);
                await _menuActionRepository.AppendAsync(entityMenuAction, sOperator);
            }
            else
            {
                entityMenuAction = await _menuActionRepository.SelectAsync(model.Id);
                if (entityMenuAction != null)
                {
                    _mapper.Map(model, entityMenuAction);
                    _menuActionRepository.Update(entityMenuAction, sOperator);
                }
            }
            return entityMenuAction;
        }

        public async Task<MenuAction> CheckMenuActionPowerAsync(int iMenuId, int iActionId)
        {
            MenuAction entityMenuAction = await _menuActionRepository.SelectAsync(new MenuAction() { ImenuId = iMenuId, IactionId = iActionId });
            return entityMenuAction;
        }
    }
}
