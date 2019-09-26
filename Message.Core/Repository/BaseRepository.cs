using Message.Core.Models;
using Message.Entity.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Message.Core.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public BaseRepository()
        //{
        //    _dbContext = GetDB();
        //}
        // public abstract DbContext GetDB();
        protected virtual IQueryable<TEntity> SearchFilter(DbContext DB, TEntity oSearchEntity, IQueryable<TEntity> query, string sOperator = null)
        {
            query = FixedQueryFilter(DB, oSearchEntity, query, sOperator);
            return query;
        }
        protected virtual IQueryable<TEntity> SearchFilterB(DbContext DB, TEntity oSearchEntity, IQueryable<TEntity> query, string sOperator = null)
        {
            return query;
        }
        protected virtual IQueryable<TEntity> FixedQueryFilter(DbContext DB, TEntity oSearchEntity, IQueryable<TEntity> query, string sOperator = null)
        {
            return query;
        }
        protected virtual IQueryable<TEntity> SelectFilter(DbContext DB, TEntity oSearchEntity, IQueryable<TEntity> query, string sOperator = null)
        {
            query = FixedQueryFilter(DB, oSearchEntity, query, sOperator);
            return query;
        }
        protected virtual IQueryable<TEntity> SelectFilterB(DbContext DB, TEntity oSearchEntity, IQueryable<TEntity> query, string sOperator = null)
        {
            query = FixedQueryFilter(DB, oSearchEntity, query, sOperator);
            return query;
        }
        protected virtual IQueryable<TEntity> OrderBySingleField(IQueryable<TEntity> query, string sSortName = null, string sSortOrder = null)
        {
            return query;
        }
        protected IQueryable<TEntity> BaseOrderBy(IQueryable<TEntity> query, int iOrderGroup, string sSortName = null, string sSortOrder = null)
        {
            if (!string.IsNullOrWhiteSpace(sSortName))
            {
                return OrderBySingleField(query, sSortName, sSortOrder);
            }
            else
            {
                return OrderBy(query, iOrderGroup);
            }
        }
        protected abstract IQueryable<TEntity> ExistsFilter(out string sErrorMessage, TEntity entity, IQueryable<TEntity> query);
        protected abstract IQueryable<TEntity> OrderBy(IQueryable<TEntity> query, int iOrderGroup = 0);
        public int Append(TEntity entity, string sOperator)
        {
            int iResult = 0;
            if (!BeforeAppend(_dbContext, entity, sOperator))
            {
                return iResult;
            }
            _dbContext.Set<TEntity>().Add(entity);
            iResult += _dbContext.SaveChanges();
            AfterAppend(_dbContext, entity, sOperator);
            ChangeDataDeleteKey(entity, sOperator);
            return iResult;
        }
        public virtual bool BeforeAppend(DbContext DB, TEntity entity, string sOperator)
        {
            if (Exists(DB, entity, out string sErrorMessage))
            {
                throw new Exception(sErrorMessage + entity.ToString());
            }
            Type t = typeof(TEntity);
            PropertyInfo propertyInfo = t.GetProperty("Id");
            propertyInfo = t.GetProperty("TcreateTime");
            propertyInfo.SetValue(entity, DateTime.Now);
            propertyInfo = t.GetProperty("TmodifyTime");
            propertyInfo.SetValue(entity, DateTime.Now);
            propertyInfo = t.GetProperty("Screater");
            propertyInfo.SetValue(entity, sOperator);
            propertyInfo = t.GetProperty("Smodifier");
            propertyInfo.SetValue(entity, sOperator);
            return true;
        }
        public virtual void AfterAppend(DbContext DB, TEntity entity, string sOperator)
        {
            ChangeDataDeleteKey(entity, sOperator);
        }
        public int Update(TEntity entity, string sOperator)
        {
            int iResult = 0;
            if (!BefoUpdate(_dbContext, entity, sOperator))
            {
                return iResult;
            }
            _dbContext.Set<TEntity>().Update(entity);
            iResult += _dbContext.SaveChanges();
            AfterUpdate(_dbContext, entity, sOperator);
            return iResult;
        }
        public virtual bool BefoUpdate(DbContext DB, TEntity entity, string sOperator)
        {
            if (Exists(DB, entity, out string sErrorMessage))
            {
                throw new Exception(sErrorMessage + entity.ToString());
            }
            Type t = typeof(TEntity);
            PropertyInfo propertyInfo = t.GetProperty("Id");
            propertyInfo = t.GetProperty("TmodifyTime");
            propertyInfo.SetValue(entity, DateTime.Now);
            propertyInfo = t.GetProperty("Smodifier");
            propertyInfo.SetValue(entity, sOperator);
            return true;

        }
        public virtual void AfterUpdate(DbContext DB, TEntity entity, string sOperator)
        {
            ChangeDataDeleteKey(entity, sOperator);
        }
        public int Delete(TEntity entity, string sOperator)
        {
            int iResult = 0;
            if (entity != null)
            {
                if (!BeforDelete(_dbContext, entity, sOperator))
                {
                    return iResult;
                }
                _dbContext.Set<TEntity>().Remove(entity);
                iResult += _dbContext.SaveChanges();
                AfterDelete(_dbContext, entity, sOperator);
            }
            return iResult;
        }
        public int Delete(int id, string sOperator)
        {
            int iResult = 0;
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                if (!BeforDelete(_dbContext, entity, sOperator))
                {
                    return iResult;
                }
                _dbContext.Set<TEntity>().Remove(entity);
                iResult += _dbContext.SaveChanges();
                AfterDelete(_dbContext, entity, sOperator);
            }
            return iResult;
        }
        public int DeleteRange(List<TEntity> lstTentity, string sOperator)
        {
            int iResult = 0;
            if (lstTentity?.Count > 0)
            {
                foreach (TEntity entity in lstTentity)
                {
                    iResult += Delete(entity, sOperator);
                }
            }
            return iResult;
        }
        public int DeleteRange(int[] arrId, string sOperator)
        {
            int iResult = 0;
            if (arrId?.Length > 0)
            {
                for (int i = 0; i < arrId.Length; i++)
                {
                    iResult += Delete(arrId[i], sOperator);
                }
            }
            return iResult;
        }
        public virtual bool BeforDelete(DbContext DB, TEntity entity, string sOperator)
        {
            return true;
        }
        public virtual void AfterDelete(DbContext DB, TEntity entity, string sOperator)
        {
            ChangeDataDeleteKey(entity, sOperator);
        }
        public bool Exists(DbContext DB, TEntity entity)
        {
            string sErrorMessage = string.Empty;
            return Exists(DB, entity, out sErrorMessage);
        }
        public bool Exists(DbContext DB, TEntity entity, out string sErrorMessage)
        {
            try
            {
                IQueryable<TEntity> query = DB.Set<TEntity>().AsQueryable();
                if (ExistsFilter(out sErrorMessage, entity, query).Count() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public TEntity Select(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            if (oSearchEntity != null)
            {
                query = SelectFilterB(_dbContext, oSearchEntity, query, sOperator);
                query = SelectFilter(_dbContext, oSearchEntity, query, sOperator);
            }
            query = BaseOrderBy(query, iOrderGroup, sSortName, sSortOrder);
            return query.FirstOrDefault();
        }
        public TEntity Select(int id, string sOperator = null)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }
        public List<TEntity> SelectALL(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            if (oSearchEntity != null)
            {
                query = SelectFilterB(_dbContext, oSearchEntity, query, sOperator);
                query = SelectFilter(_dbContext, oSearchEntity, query, sOperator);
            }
            query = BaseOrderBy(query, iOrderGroup, sSortName, sSortOrder);
            iMaxCount = iMaxCount == 0 ? query.Count() : iMaxCount;
            return query.Take(iMaxCount).ToList();
        }
        public PageInfo<TEntity> GetPageList(PageInfo<TEntity> pageInfo, TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            if (pageInfo.page > 0 && pageInfo.limit > 0)
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
                query = SearchFilterB(_dbContext, oSearchEntity, query, sOperator);
                query = SearchFilter(_dbContext, oSearchEntity, query, sOperator);
                pageInfo.count = query.Count();
                query = BaseOrderBy(query, iOrderGroup, sSortName, sSortOrder);
                IList<TEntity> lstEntity = query.Skip((pageInfo.page - 1) * pageInfo.limit).Take(pageInfo.limit).ToList();
                pageInfo.data = lstEntity;
            }
            return pageInfo;
        }
        public PageInfo<TEntity> GetPageList<Tkey>(PageInfo<TEntity> pageInfo, Expression<Func<TEntity, bool>> whereLambda = null, Func<TEntity, Tkey> orderbyLambda = null, bool isAsc = true)
        {
            if (pageInfo.page > 0 && pageInfo.limit > 0)
            {
                //总数
                pageInfo.count = _dbContext.Set<TEntity>().Where(whereLambda).Count();
                if (isAsc)
                {
                    var query = _dbContext.Set<TEntity>().Where(whereLambda)
                         .OrderBy<TEntity, Tkey>(orderbyLambda)
                         .Skip(pageInfo.limit * (pageInfo.page - 1))
                         .Take(pageInfo.limit);
                    pageInfo.data = query.ToList();
                }
                else
                {
                    var query = _dbContext.Set<TEntity>().Where(whereLambda)
                         .OrderByDescending<TEntity, Tkey>(orderbyLambda)
                         .Skip(pageInfo.limit * (pageInfo.page - 1))
                         .Take(pageInfo.limit);
                    pageInfo.data = query.ToList();
                }
            }
            return pageInfo;
        }
        public async Task<int> AppendAsync(TEntity entity, string sOperator)
        {
            int iResult = 0;
            if (!BeforeAppend(_dbContext, entity, sOperator))
            {
                return iResult;
            }
            await _dbContext.Set<TEntity>().AddAsync(entity);
            iResult = await _dbContext.SaveChangesAsync();
            AfterAppend(_dbContext, entity, sOperator);
            return iResult;
        }
        public Task<PageInfo<TEntity>> GetPageListAsync(PageInfo<TEntity> pageInfo, int iOrderGroup = 0, string sOperator = null)
        {
            //using (DbContext DB = GetDB())
            //{
            //    DB.Set<TEntity>().ToListAsync();
            //    IQueryable<TEntity> query = DB.Set<TEntity>().AsQueryable();
            //    pageInfo.count = query.Count();
            //    query = OrderBy(query, iOrderGroup);
            //    IList<TEntity> lstTEntity = query.Skip((pageInfo.page - 1) * pageInfo.limit).Take(pageInfo.limit).ToList();
            //    pageInfo.data = lstTEntity;
            //};
            //return pageInfo;
            return null;
        }

        public async Task<TEntity> SelectAsync(int id, string sOperator = null)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> SelectAsync(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            if (oSearchEntity != null)
            {
                query = SelectFilterB(_dbContext, oSearchEntity, query, sOperator);
                query = SelectFilter(_dbContext, oSearchEntity, query, sOperator);
            }
            query = BaseOrderBy(query, iOrderGroup, sSortName, sSortOrder);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<TEntity>> SelectALLAsync(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            if (oSearchEntity != null)
            {
                query = SelectFilterB(_dbContext, oSearchEntity, query, sOperator);
                query = SelectFilter(_dbContext, oSearchEntity, query, sOperator);
            }
            query = BaseOrderBy(query, iOrderGroup, sSortName, sSortOrder);
            iMaxCount = iMaxCount == 0 ? query.Count() : iMaxCount;
            return await query.Take(iMaxCount).ToListAsync();
        }

        public virtual void ChangeDataDeleteKey(TEntity entity, string sOperator)
        {

        }
        public int AppendRange(List<TEntity> lstEntity, string sOperator)
        {
            int iResult = 0;
            if (lstEntity.Any())
            {
                foreach (TEntity entity in lstEntity)
                {
                    iResult += Append(entity, sOperator);
                }
            }
            return iResult;
        }
        public async Task<int> AppendRangeAsync(List<TEntity> lstEntity, string sOperator)
        {
            int iResult = 0;
            if (lstEntity.Any())
            {
                foreach (TEntity entity in lstEntity)
                {
                    iResult += await AppendAsync(entity, sOperator);
                }
            }
            return iResult;
        }

        public int UpdateRange(List<TEntity> lstEntity, string sOperator)
        {
            int iResult = 0;
            if (lstEntity.Any())
            {
                foreach (TEntity entity in lstEntity)
                {
                    iResult += Update(entity, sOperator);
                }
            }
            return iResult;
        }
    }
}
