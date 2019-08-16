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
    public sealed partial class UserInfoRepository : MessageManagementDBRepository<UserInfo>, IUserInfoRepository
    {
        //  public UserInfoRepository(MessageManagementContext messagemanagementcontext) : base(messagemanagementcontext) { }
        //public UserInfoRepository(MessageManagementContext messagemanagementcontext)
        //{
        //    _dbContext = messagemanagementcontext;
        //}

        protected override IQueryable<UserInfo> SearchFilterB(DbContext DB, UserInfo oSearchEntity, IQueryable<UserInfo> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SloginName)) { query = query.Where(x => x.SloginName.Contains(oSearchEntity.SloginName)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SuserPhone)) { query = query.Where(x => x.SuserPhone.Contains(oSearchEntity.SuserPhone)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SuserEmail)) { query = query.Where(x => x.SuserEmail.Contains(oSearchEntity.SuserEmail)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SuserName)) { query = query.Where(x => x.SuserName.Contains(oSearchEntity.SuserName)); }
                if (oSearchEntity.BisLock.HasValue) { query = query.Where(x => x.BisLock == oSearchEntity.BisLock.Value); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks.Contains(oSearchEntity.Sremarks)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
            }
            return query;
        }
        protected override IQueryable<UserInfo> SelectFilterB(DbContext DB, UserInfo oSearchEntity, IQueryable<UserInfo> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SloginName)) { query = query.Where(x => x.SloginName == oSearchEntity.SloginName); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SuserPhone)) { query = query.Where(x => x.SuserPhone == oSearchEntity.SuserPhone); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SuserEmail)) { query = query.Where(x => x.SuserEmail == oSearchEntity.SuserEmail); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SuserName)) { query = query.Where(x => x.SuserName == oSearchEntity.SuserName); }
                if (oSearchEntity.BisLock.HasValue) { query = query.Where(x => x.BisLock == oSearchEntity.BisLock.Value); }

                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks == oSearchEntity.Sremarks); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
            }
            return query;
        }
        protected override IQueryable<UserInfo> OrderBySingleField(IQueryable<UserInfo> query, string sSortName = null, string sSortOrder = null)
        {
            if (sSortOrder == "desc")
            {
                switch (sSortName)
                {
                    case "Id": return query.OrderByDescending(x => x.Id).ThenBy(x => x.Id);
                    case "SloginName": return query.OrderByDescending(x => x.SloginName).ThenBy(x => x.Id);
                    case "SuserName": return query.OrderByDescending(x => x.SuserName).ThenBy(x => x.Id);
                    case "Smodifier": return query.OrderByDescending(x => x.Smodifier).ThenBy(x => x.Id);
                    case "Sremarks": return query.OrderByDescending(x => x.Sremarks).ThenBy(x => x.Id);
                    case "Screater": return query.OrderByDescending(x => x.Screater).ThenBy(x => x.Id);
                    case "TcreateTime": return query.OrderByDescending(x => x.TcreateTime).ThenBy(x => x.Id);
                    default: return query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
                }
            }
            else
            {
                switch (sSortName)
                {
                    case "Id": return query.OrderBy(x => x.Id).ThenBy(x => x.Id);
                    case "SloginName": return query.OrderBy(x => x.SloginName).ThenBy(x => x.Id);
                    case "SuserName": return query.OrderBy(x => x.SuserName).ThenBy(x => x.Id);
                    case "Smodifier": return query.OrderBy(x => x.Smodifier).ThenBy(x => x.Id);
                    case "Sremarks": return query.OrderBy(x => x.Sremarks).ThenBy(x => x.Id);
                    case "Screater": return query.OrderBy(x => x.Screater).ThenBy(x => x.Id);
                    case "TcreateTime": return query.OrderBy(x => x.TcreateTime).ThenBy(x => x.Id);
                    default: return query.OrderBy(x => x.TmodifyTime).ThenBy(x => x.Id);
                }
            }
        }

    }
}
