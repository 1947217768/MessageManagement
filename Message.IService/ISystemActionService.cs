using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.SystemAction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface ISystemActionService
    {
        PageInfo<ViewSystemAction> GetPageList(PageInfo<ViewSystemAction> pageInfo, ViewSystemAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);


        List<SystemAction> SelectALL(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        SystemAction Select(int id, string sOperator = null);
        SystemAction Select(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entitySystemAction">条件</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup">排序</param>
        /// <param name="iMaxCount">最大返回数据条数</param>
        /// <param name="sSortName">排序名称</param>
        /// <param name="sSortOrder">排序方式</param>
        /// <returns></returns>
        Task<List<SystemAction>> SelectALLAsync(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <param name="sOperator">操作人</param>
        /// <returns>返回实体</returns>
        Task<SystemAction> SelectAsync(int id, string sOperator = null);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="entitySystemAction">实体</param>
        /// <param name="sOperator">操作人</param>
        /// <param name="iOrderGroup"></param>
        /// <param name="sSortName"></param>
        /// <param name="sSortOrder"></param>
        /// <returns></returns>
        Task<SystemAction> SelectAsync(SystemAction entitySystemAction = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<SystemAction> AddOrModifySystemActionAsync(SystemAction model, string sOperator);
        Task<int> AppendAsync(SystemAction entitySystemAction, string sOperator);
        int Append(SystemAction entitySystemAction, string sOperator);
    }
}