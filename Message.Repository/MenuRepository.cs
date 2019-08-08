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
    public partial class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        protected override IQueryable<Menu> ExistsFilter(out string sErrorMessage, Menu entity, IQueryable<Menu> query)
        {
            query = query.Where(x => x.Id != entity.Id && x.Sname == entity.Sname);
            sErrorMessage = $"[{entity.Sname}]已经存在!";
            return query;
        }
        protected override IQueryable<Menu> OrderBy(IQueryable<Menu> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
        public override bool BeforeAppend(DbContext DB, Menu entity, string sOperator)
        {
            return base.BeforeAppend(DB, entity, sOperator);
        }
        public override void AfterAppend(DbContext DB, Menu entity, string sOperator)
        {
            base.AfterAppend(DB, entity, sOperator);
        }
        public override void ChangeDataDeleteKey(Menu entity, string sOperator)
        {
            string[] arrUser_Menu = RedisHelper.Keys("*_Menu");
            for (int i = 0; i < arrUser_Menu.Length; i++)
            {
                RedisHelper.Del(arrUser_Menu[i]);
            }
            base.ChangeDataDeleteKey(entity, sOperator);
        }
    }
}
