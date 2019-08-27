using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Repository
{
    public partial class RoleMenuRepository : MessageManagementDBRepository<RoleMenu>, IRoleMenuRepository
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        public RoleMenuRepository(IUserRoleRepository userRoleRepository, IUserInfoRepository userInfoRepository)
        {
            _userRoleRepository = userRoleRepository;
            _userInfoRepository = userInfoRepository;
        }
        protected override IQueryable<RoleMenu> ExistsFilter(out string sErrorMessage, RoleMenu entity, IQueryable<RoleMenu> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.ImenuId == entity.ImenuId && x.IroleId == entity.IroleId);
            sErrorMessage = $"此角色已拥有此菜单!";
            return query;
        }
        protected override IQueryable<RoleMenu> OrderBy(IQueryable<RoleMenu> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override void ChangeDataDeleteKey(RoleMenu entity, string sOperator)
        {
            List<UserRole> lstUserRole = _userRoleRepository.SelectALL(new UserRole() { IroleId = entity.IroleId });
            if (lstUserRole?.Count > 0)
            {
                foreach (UserRole entityUserRole in lstUserRole)
                {
                    UserInfo entityUserInfo = _userInfoRepository.Select(entityUserRole.IuserId);
                    //用户菜树Redis Key
                    string sUserTreeItemMenuKey = "UserTreeItemMenu_" + entityUserInfo.Id;
                    string sUserMenuKey = "UserMenu_" + entityUserInfo.Id;
                    if (RedisHelper.Exists(sUserMenuKey))
                    {
                        RedisHelper.Del(sUserMenuKey);
                    }
                    if (RedisHelper.Exists(sUserTreeItemMenuKey))
                    {
                        RedisHelper.Del(sUserTreeItemMenuKey);
                    }
                }
            }
            base.ChangeDataDeleteKey(entity, sOperator);
        }
    }
}
