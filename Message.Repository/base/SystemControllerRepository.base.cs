﻿using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.Repository
{
    public sealed partial class SystemControllerRepository : MessageManagementDBRepository<SystemController>, ISystemControllerRepository
    {
        //  public SystemControllerRepository(MessageManagementContext messagemanagementcontext) : base(messagemanagementcontext) { }
        protected override IQueryable<SystemController> SearchFilterB(DbContext DB, SystemController oSearchEntity, IQueryable<SystemController> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.ScontrollerName)) { query = query.Where(x => x.ScontrollerName.Contains(oSearchEntity.ScontrollerName)); }

                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks.Contains(oSearchEntity.Sremarks)); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
            }
            return query;
        }
        protected override IQueryable<SystemController> SelectFilterB(DbContext DB, SystemController oSearchEntity, IQueryable<SystemController> query, string sOperator = null)
        {
            if (oSearchEntity != null)
            {
                if (oSearchEntity.Id != 0) { query = query.Where(x => x.Id == oSearchEntity.Id); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.ScontrollerName)) { query = query.Where(x => x.ScontrollerName.Contains(oSearchEntity.ScontrollerName)); }

                if (!string.IsNullOrWhiteSpace(oSearchEntity.Sremarks)) { query = query.Where(x => x.Sremarks == oSearchEntity.Sremarks); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Screater)) { query = query.Where(x => x.Screater == oSearchEntity.Screater); }
                if (!string.IsNullOrWhiteSpace(oSearchEntity.Smodifier)) { query = query.Where(x => x.Smodifier == oSearchEntity.Smodifier); }
                if (oSearchEntity.TcreateTime != null) { query = query.Where(x => x.TcreateTime == oSearchEntity.TcreateTime); }
                if (oSearchEntity.TmodifyTime != null) { query = query.Where(x => x.TmodifyTime == oSearchEntity.TmodifyTime); }
            }
            return query;
        }
        protected override IQueryable<SystemController> OrderBySingleField(IQueryable<SystemController> query, string sSortName = null, string sSortOrder = null)
        {
            if (sSortOrder == "desc")
            {
                switch (sSortName)
                {
                    case "Id": return query.OrderByDescending(x => x.Id).ThenBy(x => x.Id);
                    case "ScontrollerName": return query.OrderByDescending(x => x.ScontrollerName).ThenBy(x => x.Id);
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
                    case "ScontrollerName": return query.OrderBy(x => x.ScontrollerName).ThenBy(x => x.Id);
                    case "Sremarks": return query.OrderBy(x => x.Sremarks).ThenBy(x => x.Id);
                    case "Screater": return query.OrderBy(x => x.Screater).ThenBy(x => x.Id);
                    case "TcreateTime": return query.OrderBy(x => x.TcreateTime).ThenBy(x => x.Id);
                    default: return query.OrderBy(x => x.TmodifyTime).ThenBy(x => x.Id);
                }
            }
        }

    }
}
