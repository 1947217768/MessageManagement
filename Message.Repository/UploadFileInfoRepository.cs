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
    public partial class UploadFileInfoRepository : MessageManagementDBRepository<UploadFileInfo>, IUploadFileInfoRepository
    {
        protected override IQueryable<UploadFileInfo> ExistsFilter(out string sErrorMessage, UploadFileInfo entity, IQueryable<UploadFileInfo> query)
        {
            query = query.Where(x => false);
            sErrorMessage = $"";
            return query;
        }
        protected override IQueryable<UploadFileInfo> OrderBy(IQueryable<UploadFileInfo> query, int iOrderGroup = 0)
        {
            switch (iOrderGroup)
            {
                default:
                    return query = query.OrderByDescending(x => x.TmodifyTime).ThenBy(x => x.Id);
            }
        }
    }
}
