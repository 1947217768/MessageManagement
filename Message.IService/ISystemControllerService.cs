using Message.Core.Models;
using Message.Entity.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface ISystemControllerService
    {
        PageInfo<SystemController> GetPageList(PageInfo<SystemController> pageInfo, SystemController oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        List<SystemController> SelectALL(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        SystemController Select(int id, string sOperator = null);
        SystemController Select(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entitySystemController">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<SystemController>> SelectALLAsync(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<SystemController> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entitySystemController">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<SystemController> SelectAsync(SystemController entitySystemController = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<SystemController> AddOrModifySystemControllerAsync(SystemController model, string sOperator);
        Task<int> AppendAsync(SystemController entitySystemController, string sOperator);
        int Append(SystemController entitySystemController, string sOperator);
        bool DeleteRange(int[] arrId, string sOperator);
    }
}