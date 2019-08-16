using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IRepository;
using Message.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Message.Service
{
    public class UploadFileInfoService : IUploadFileInfoService
    {
        private readonly IUploadFileInfoRepository _UploadFileInfoRepository;
        private readonly IHostEnvironment _hostEnvironment;
        public UploadFileInfoService(IUploadFileInfoRepository UploadFileInfoRepository, IHostEnvironment hostEnvironment)
        {
            _UploadFileInfoRepository = UploadFileInfoRepository;
            _hostEnvironment = hostEnvironment;
        }


        public PageInfo<UploadFileInfo> GetPageList(PageInfo<UploadFileInfo> pageInfo, UploadFileInfo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _UploadFileInfoRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public async Task<UploadFileInfo> GetFileInfoAsync(int iFileId, string sOperator = null)
        {
            return await _UploadFileInfoRepository.SelectAsync(iFileId, sOperator);
        }

        [Obsolete]
        public async Task<UploadFileInfo> AppendFileAsync(IFormFile file, string sOperator, string sDirectoryName = null)
        {
            UploadFileInfo uploadFileInfo = new UploadFileInfo();
            if (file != null)
            {
                sDirectoryName = string.IsNullOrWhiteSpace(sDirectoryName) ? $"uploads\\{DateTime.Now.ToString("yyyyMMdd")}\\" : sDirectoryName;
                string sFileType = Path.GetExtension(file.FileName);
                //目录
                string sDirectoryPath = _hostEnvironment.ContentRootPath + "\\wwwroot\\" + sDirectoryName;
                // string sDirectoryPath = "\\" + sDirectoryName;

                //新文件名
                string sFileName = Guid.NewGuid().ToString("N") + sFileType;
                //完整路径
                string sFullPath = sDirectoryPath + sFileName;
                //相对路径
                string sRelativePath = string.Format("/{1}{0}", sFileName, sDirectoryName.Replace("\\", "/"));
                if (!Directory.Exists(sDirectoryPath))
                {
                    Directory.CreateDirectory(sDirectoryPath);
                }
                uploadFileInfo.SfileName = sFileName;
                uploadFileInfo.SfilePath = sFullPath;
                uploadFileInfo.SfileType = sFileType;
                uploadFileInfo.SoriginalFileName = Path.GetFileName(file.FileName);
                uploadFileInfo.Isize = Convert.ToInt32(file.Length);
                uploadFileInfo.SrelativePath = sRelativePath;
                uploadFileInfo.Uid = System.Guid.NewGuid();
                try
                {

                    Stream stream = new FileStream(sFullPath, FileMode.Create);
                    file.CopyTo(stream);
                    await _UploadFileInfoRepository.InsertAsync(uploadFileInfo, sOperator);
                    await file.CopyToAsync(stream);
                    stream.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return uploadFileInfo;
        }
        public async Task<UploadFileInfo> GetFileInfoAsync(UploadFileInfo entity, string sOperator = null)
        {
            return await _UploadFileInfoRepository.SelectAsync(entity, sOperator);
        }
    }
}
