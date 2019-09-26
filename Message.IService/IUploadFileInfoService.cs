using Message.Core.Models;
using Message.Entity.Mapping;
using Microsoft.AspNetCore.Http;
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
        /// 查找文件信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<UploadFileInfo> GetFileInfoAsync(UploadFileInfo entity, string sOperator = null);

        bool DeleteFile(string sFilePath);

    }
}