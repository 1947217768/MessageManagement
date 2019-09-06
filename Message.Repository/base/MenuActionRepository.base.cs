using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Message.Repository
{
    public sealed partial class MenuActionRepository : MessageManagementDBRepository<MenuAction>, IMenuActionRepository
    {
        protected override IQueryable<MenuAction> SearchFilterB(DbContext DB, MenuAction oSearchEntity, IQueryable<MenuAction> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks.Contains(oSearchEntity.Sremarks)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater.Contains(oSearchEntity.Screater)); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier.Contains(oSearchEntity.Smodifier)); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
                if (oSearchEntity.ImenuId != 0) { query = query.Where(x => x.ImenuId == oSearchEntity.ImenuId); }
                if (oSearchEntity.IactionId != 0) { query = query.Where(x => x.IactionId == oSearchEntity.IactionId); }
                if (oSearchEntity.BisValid.HasValue) { query = query.Where(x => x.BisValid == oSearchEntity.BisValid.Value); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sexplain)) { query = query.Where(x => x.Sexplain.Contains(oSearchEntity.Sexplain)); }
            }
            return query;
        }
        protected override IQueryable<MenuAction> SelectFilterB(DbContext DB, MenuAction oSearchEntity, IQueryable<MenuAction> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks == oSearchEntity.Sremarks); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
                if (oSearchEntity.ImenuId != 0) { query = query.Where(x => x.ImenuId == oSearchEntity.ImenuId); }
                if (oSearchEntity.IactionId != 0) { query = query.Where(x => x.IactionId == oSearchEntity.IactionId); }
                if (oSearchEntity.BisValid.HasValue) { query = query.Where(x => x.BisValid == oSearchEntity.BisValid.Value); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sexplain)) { query = query.Where(x => x.Sexplain == oSearchEntity.Sexplain); }
            }
            return query;
        }
        protected override IQueryable<MenuAction> OrderBySingleField(IQueryable<MenuAction> query, string sSortName = null, string sSortOrder = null)
        {
            if (sSortOrder == "desc")
            {
                switch (sSortName)
                {
                    case "Id": return query.OrderByDescending(x => x.Id).ThenBy(x => x.Id);
                    case "Sremarks": return query.OrderByDescending(x => x.Sremarks).ThenBy(x => x.Id);
                    case "Screater": return query.OrderByDescending(x => x.Screater).ThenBy(x => x.Id);
                    case "TcreateTime": return query.OrderByDescending(x => x.TcreateTime).ThenBy(x => x.Id);
                    case "Smodifier": return query.OrderByDescending(x => x.Smodifier).ThenBy(x => x.Id);
                    case "TmodifyTime": return query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
                    case "ImenuId": return query.OrderByDescending(x => x.ImenuId).ThenBy(x => x.Id);
                    case "IactionId": return query.OrderByDescending(x => x.IactionId).ThenBy(x => x.Id);
                    case "Sexplain": return query.OrderByDescending(x => x.Sexplain).ThenBy(x => x.Id);
                    default: return query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
                }
            }
            else
            {
                switch (sSortName)
                {
                    case "Id": return query.OrderBy(x => x.Id).ThenBy(x => x.Id);
                    case "Sremarks": return query.OrderBy(x => x.Sremarks).ThenBy(x => x.Id);
                    case "Screater": return query.OrderBy(x => x.Screater).ThenBy(x => x.Id);
                    case "TcreateTime": return query.OrderBy(x => x.TcreateTime).ThenBy(x => x.Id);
                    case "Smodifier": return query.OrderBy(x => x.Smodifier).ThenBy(x => x.Id);
                    case "TmodifyTime": return query.OrderBy(x => x.TmodifyTime).ThenBy(x => x.Id);
                    case "ImenuId": return query.OrderBy(x => x.ImenuId).ThenBy(x => x.Id);
                    case "IactionId": return query.OrderBy(x => x.IactionId).ThenBy(x => x.Id);
                    case "Sexplain": return query.OrderBy(x => x.Sexplain).ThenBy(x => x.Id);
                    default: return query.OrderBy(x => x.TmodifyTime).ThenBy(x => x.Id);
                }
            }
        }

    }
}
