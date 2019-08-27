using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.Repository
{
    public partial class UserInfoRepository : MessageManagementDBRepository<UserInfo>, IUserInfoRepository
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUploadFileInfoRepository _uploadFileInfoRepository;
        public UserInfoRepository(IUserRoleRepository userRoleRepository, IUploadFileInfoRepository uploadFileInfoRepository)
        {
            _userRoleRepository = userRoleRepository;
            _uploadFileInfoRepository = uploadFileInfoRepository;
        }
        protected override IQueryable<UserInfo> ExistsFilter(out string sErrorMessage, UserInfo entity, IQueryable<UserInfo> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.SloginName == entity.SloginName);
            sErrorMessage = $"登录名[{entity.SloginName}]已经存在!";
            return query;
        }
        protected override IQueryable<UserInfo> OrderBy(IQueryable<UserInfo> query, int iOrderGroup = 0)
        {

            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override bool BeforDelete(DbContext DB, UserInfo entity, string sOperator)
        {

            return base.BeforDelete(DB, entity, sOperator);
        }
        public override void AfterDelete(DbContext DB, UserInfo entity, string sOperator)
        {
            _userRoleRepository.DeleteRange(_userRoleRepository.SelectALL(new UserRole() { IuserId = entity.Id }), sOperator);
            _uploadFileInfoRepository.Delete(_uploadFileInfoRepository.Select(entity.IfileInfoId), sOperator);
            base.AfterDelete(DB, entity, sOperator);
        }
    }
}
