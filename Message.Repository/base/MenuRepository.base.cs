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
    public sealed partial class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(MessageManagementContext messagemanagementcontext) : base(messagemanagementcontext) { }
        //public MenuRepository(MessageManagementContext messagemanagementcontext)
        //{
        //    _dbContext = messagemanagementcontext;
        //}
        protected override IQueryable<Menu> SearchFilterB(DbContext DB, Menu oSearchEntity, IQueryable<Menu> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (oSearchEntity.IparentId != 0) { query = query.Where(x => x.IparentId == oSearchEntity.IparentId); }
                if (oSearchEntity.Isort != 0) { query = query.Where(x => x.Isort == oSearchEntity.Isort); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sname)) { query = query.Where(x => x.Sname.Contains(oSearchEntity.Sname)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SiconUrl)) { query = query.Where(x => x.SiconUrl.Contains(oSearchEntity.SiconUrl)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SlinkUrl)) { query = query.Where(x => x.SlinkUrl.Contains(oSearchEntity.SlinkUrl)); }
                if (oSearchEntity.Bdisplay.HasValue) { query = query.Where(x => x.Bdisplay == oSearchEntity.Bdisplay.Value); }

                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks.Contains(oSearchEntity.Sremarks)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
            }
            return query;
        }
        protected override IQueryable<Menu> SelectFilterB(DbContext DB, Menu oSearchEntity, IQueryable<Menu> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (oSearchEntity.IparentId != 0) { query = query.Where(x => x.IparentId == oSearchEntity.IparentId); }
                if (oSearchEntity.Isort != 0) { query = query.Where(x => x.Isort == oSearchEntity.Isort); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sname)) { query = query.Where(x => x.Sname == oSearchEntity.Sname); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SiconUrl)) { query = query.Where(x => x.SiconUrl == oSearchEntity.SiconUrl); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.SlinkUrl)) { query = query.Where(x => x.SlinkUrl == oSearchEntity.SlinkUrl); }
                if (oSearchEntity.Bdisplay.HasValue) { query = query.Where(x => x.Bdisplay == oSearchEntity.Bdisplay.Value); }

                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks == oSearchEntity.Sremarks); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
            }
            return query;
        }
        protected override IQueryable<Menu> OrderBySingleField(IQueryable<Menu> query, string sSortName = null, string sSortOrder = null)
        {
            if (sSortOrder == "desc")
            {
                switch (sSortName)
                {
                    case "Id": return query.OrderByDescending(x => x.Id).ThenBy(x => x.Id);
                    case "IparentId": return query.OrderByDescending(x => x.IparentId).ThenBy(x => x.Id);
                    case "Isort": return query.OrderByDescending(x => x.Isort).ThenBy(x => x.Id);
                    case "SlinkUrl": return query.OrderByDescending(x => x.SlinkUrl).ThenBy(x => x.Id);
                    case "SiconUrl": return query.OrderByDescending(x => x.SiconUrl).ThenBy(x => x.Id);
                    case "Smodifier": return query.OrderByDescending(x => x.Smodifier).ThenBy(x => x.Id);
                    case "Sname": return query.OrderByDescending(x => x.Sname).ThenBy(x => x.Id);
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
                    case "IparentId": return query.OrderBy(x => x.IparentId).ThenBy(x => x.Id);
                    case "Isort": return query.OrderBy(x => x.Isort).ThenBy(x => x.Id);
                    case "SlinkUrl": return query.OrderBy(x => x.SlinkUrl).ThenBy(x => x.Id);
                    case "SiconUrl": return query.OrderBy(x => x.SiconUrl).ThenBy(x => x.Id);
                    case "Smodifier": return query.OrderBy(x => x.Smodifier).ThenBy(x => x.Id);
                    case "Sname": return query.OrderBy(x => x.Sname).ThenBy(x => x.Id);
                    case "Sremarks": return query.OrderBy(x => x.Sremarks).ThenBy(x => x.Id);
                    case "Screater": return query.OrderBy(x => x.Screater).ThenBy(x => x.Id);
                    case "TcreateTime": return query.OrderBy(x => x.TcreateTime).ThenBy(x => x.Id);
                    default: return query.OrderBy(x => x.TmodifyTime).ThenBy(x => x.Id);
                }
            }
        }

    }
}
