using Message.Core.Models;
using Message.Entity.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IFieldRelationService
    {
        PageInfo<FieldRelation> GetPageList(PageInfo<FieldRelation> pageInfo, FieldRelation oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);


        List<FieldRelation> SelectALL(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        FieldRelation Select(int id, string sOperator = null);
        FieldRelation Select(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityFieldRelation">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<FieldRelation>> SelectALLAsync(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<FieldRelation> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityFieldRelation">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<FieldRelation> SelectAsync(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<FieldRelation> AddOrModifyFieldRelationAsync(FieldRelation model, string sOperator);
        Task<int> AppendAsync(FieldRelation entityFieldRelation, string sOperator);
        int Append(FieldRelation entityFieldRelation, string sOperator);
    }
}