using Message.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Core.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <returns></returns>
        int Append(TEntity entity, string sOperator);
        /// <summary>
        /// 插入实体前
        /// </summary>
        /// <param name="DB">上下文</param>
        /// <param name="entity">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <returns></returns>
        bool BeforeAppend(DbContext DB, TEntity entity, string sOperator);
        /// <summary>
        /// 插入实体后
        /// </summary>
        /// <param name="DB">上下文</param>
        /// <param name="entity">实体</param>
        /// <param name="sOperator">操作人</param>
        void AfterAppend(DbContext DB, TEntity entity, string sOperator);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <returns></returns>
        int Update(TEntity entity, string sOperator);
        /// <summary>
        /// 修改前
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="entity"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        bool BefoUpdate(DbContext DB, TEntity entity, string sOperator);
        /// <summary>
        /// 修改后
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="entity"></param>
        /// <param name="sOperator"></param>
        void AfterUpdate(DbContext DB, TEntity entity, string sOperator);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        int Delete(TEntity entity, string sOperator);
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        int Delete(int id, string sOperator);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="lstTentity"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        int DeleteRange(List<TEntity> lstTentity, string sOperator);
        /// <summary>
        /// 根据ID批量删除
        /// </summary>
        /// <param name="arrId"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        int DeleteRange(int[] arrId, string sOperator);
        /// <summary>
        /// 删除前
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="entity"></param>
        /// <param name="sOperator"></param>
        /// <returns></returns>
        bool BeforDelete(DbContext DB, TEntity entity, string sOperator);
        /// <summary>
        /// 删除后
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="entity"></param>
        /// <param name="sOperator"></param>
        void AfterDelete(DbContext DB, TEntity entity, string sOperator);
        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <param name="oSearchEntity">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns>实体</returns>
        TEntity Select(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>实体</returns>
        TEntity Select(int id, string sOperator = null);
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="oSearchEntity">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns>集合</returns>
        List<TEntity> SelectALL(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        PageInfo<TEntity> GetPageList(PageInfo<TEntity> pageInfo, TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 查询实体是否存在(不返回消息)
        /// </summary>
        /// <param name="DB">上下文</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Exists(DbContext DB, TEntity entity);
        /// <summary>        
        ///  查询实体是否存在(不返回消息)
        /// </summary>
        /// <param name="DB">上下文</param>
        /// <param name="entity">实体</param>
        /// <param name="sErrorMessage">错误消息</param>
        /// <returns></returns>
        bool Exists(DbContext DB, TEntity entity, out string sErrorMessage);
        void ChangeDataDeleteKey(TEntity entity, string sOperator);
        PageInfo<TEntity> GetPageList<Tkey>(PageInfo<TEntity> pageInfo, Expression<Func<TEntity, bool>> whereLambda = null, Func<TEntity, Tkey> orderbyLambda = null, bool isAsc = true);

        Task<int> InsertAsync(TEntity entity, string sOperator);
        Task<TEntity> SelectAsync(int id, string sOperator = null);
        Task<TEntity> SelectAsync(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);

        Task<List<TEntity>> SelectALLAsync(TEntity oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        Task<PageInfo<TEntity>> GetPageListAsync(PageInfo<TEntity> pageInfo, int iOrderGroup = 0, string sOperator = null);
    }
}
