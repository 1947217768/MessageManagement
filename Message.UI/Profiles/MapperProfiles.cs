using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.DataTable;
using Message.Entity.ViewEntity.Menu;
using Message.Entity.ViewEntity.MenuAction;
using Message.Entity.ViewEntity.Roles;
using Message.Entity.ViewEntity.SystemAction;
using Message.Entity.ViewEntity.TableFiled;
using Message.Entity.ViewEntity.UserInfo;
using System.Collections.Generic;

namespace Message.UI.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            #region Menu
            CreateMap<AddOrModifyMenu, Menu>();
            CreateMap<ChangeMenuState, Menu>();
            #endregion
            #region UserInfo
            CreateMap<AddOrModifyUserInfo, UserInfo>();
            CreateMap<UserInfo, AddOrModifyUserInfo>();
            #endregion
            #region Roles
            CreateMap<AddOrModifyRoles, Roles>();
            #endregion
            #region SystemAction
            CreateMap<SystemAction, ViewSystemAction>();
            CreateMap<ViewSystemAction, SystemAction>();
            CreateMap<List<SystemAction>, List<ViewSystemAction>>();
            CreateMap<List<ViewSystemAction>, List<SystemAction>>();
            CreateMap<PageInfo<SystemAction>, PageInfo<ViewSystemAction>>();
            CreateMap<PageInfo<ViewSystemAction>, PageInfo<SystemAction>>();
            #endregion
            #region DataTable
            CreateMap<ViewDataTable, DataTable>();
            CreateMap<DataTable, ViewDataTable>();
            CreateMap<PageInfo<ViewDataTable>, PageInfo<DataTable>>();
            CreateMap<PageInfo<DataTable>, PageInfo<ViewDataTable>>();
            #endregion

            #region TableFiled
            CreateMap<ViewTableFiled, TableFiled>();
            CreateMap<TableFiled, ViewTableFiled>();
            CreateMap<PageInfo<ViewTableFiled>, PageInfo<TableFiled>>();
            CreateMap<PageInfo<TableFiled>, PageInfo<ViewTableFiled>>();
            #endregion

            #region MenuAction
            CreateMap<ViewMenuAction, MenuAction>();
            CreateMap<MenuAction, ViewMenuAction>();
            CreateMap<MenuAction, AddOrModifyMenuAction>();
            CreateMap<AddOrModifyMenuAction, MenuAction>();
            CreateMap<PageInfo<ViewMenuAction>, PageInfo<MenuAction>>();
            CreateMap<PageInfo<MenuAction>, PageInfo<ViewMenuAction>>();
            #endregion
        }
    }
}
