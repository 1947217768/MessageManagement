using Message.Core.Models;
using Message.Entity.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IDataBaseService
    {
        PageInfo<DataBase> GetPageList(PageInfo<DataBase> pageInfo, DataBase oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);


        List<DataBase> SelectALL(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        DataBase Select(int id, string sOperator = null);
        DataBase Select(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entityDataBase">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<DataBase>> SelectALLAsync(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<DataBase> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entityDataBase">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<DataBase> SelectAsync(DataBase entityDataBase = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<DataBase> AddOrModifyDataBaseAsync(DataBase model, string sOperator);
        Task<int> AppendAsync(DataBase entityDataBase, string sOperator);
        int Append(DataBase entityDataBase, string sOperator);
    }
}