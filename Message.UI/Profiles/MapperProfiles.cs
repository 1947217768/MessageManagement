using AutoMapper;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Menu;
using Message.Entity.ViewEntity.Roles;
using Message.Entity.ViewEntity.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
