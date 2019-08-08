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
    public interface IUploadFileInfoService
    {

        PageInfo<UploadFileInfo> GetPageList(PageInfo<UploadFileInfo> pageInfo, UploadFileInfo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        /// <summary>
        /// 根据文件ID查找文件信息
        /// </summary>
        /// <param name="iFileId"></param>
        /// <returns></returns>
        Task<UploadFileInfo> GetFileInfoAsync(int iFileId, string sOperator = null);

        Task<UploadFileInfo> AppendFileAsync(IFormFile file, string sOperator, string sDirectoryName = null);
        /// <summary>
        /// 根据Guid查找文件信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<UploadFileInfo> GetFileInfoAsync(Guid guid, string sOperator = null);

    }
}