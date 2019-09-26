using Message.Core.Repository;
using Message.Entity.Mapping;
using Message.IRepository;
using System.Linq;

namespace Message.Repository
{
    public partial class MemoRepository : MessageManagementDBRepository<Memo>, IMemoRepository
    {
        protected override IQueryable<Memo> ExistsFilter(out string sErrorMessage, Memo entity, IQueryable<Memo> query)
        {
            query = query.Where(x => false);
            sErrorMessage = $"";
            return query;
        }
        protected override IQueryable<Memo> OrderBy(IQueryable<Memo> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
    }
}
