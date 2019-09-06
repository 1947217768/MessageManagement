using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.TableFiled;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface ITableFiledService
    {
        PageInfo<ViewTableFiled> GetPageList(PageInfo<ViewTableFiled> pageInfo, ViewTableFiled oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);


        List<TableFiled> SelectALL(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        TableFiled Select(int id, string sOperator = null);
        TableFiled Select(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityTableFiled">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<TableFiled>> SelectALLAsync(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<TableFiled> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityTableFiled">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<TableFiled> SelectAsync(TableFiled entityTableFiled = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<TableFiled> AddOrModifyTableFiledAsync(TableFiled model, string sOperator);
        Task<int> AppendAsync(TableFiled entityTableFiled, string sOperator);
        int Append(TableFiled entityTableFiled, string sOperator);

        Task<List<ViewTableFiled>> GetViewTableInfoAsync(int iTableId = 0);
    }
}