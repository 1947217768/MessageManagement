using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Memo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IMemoService
    {
        PageInfo<Memo> GetPageList(PageInfo<Memo> pageInfo, Memo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        bool DeleteRange(int[] arrId, string sOperator);

        List<Memo> SelectALL(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);

        Memo Select(int id, string sOperator = null);

        Memo Select(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<List<Memo>> SelectALLAsync(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null);

        Task<Memo> SelectAsync(int id, string sOperator = null);

        Task<Memo> SelectAsync(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);

        Task<Memo> AddOrModifyMemorandumAsync(AddOrModifyMemo model, string sOperator);

        Task<int> AppendAsync(Memo entityMemorandum, string sOperator);

        int Append(Memo entityMemorandum, string sOperator);

        int Update(Memo entityMemorandum, string sOperator);


    }
}