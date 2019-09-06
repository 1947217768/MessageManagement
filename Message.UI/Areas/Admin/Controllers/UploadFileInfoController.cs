using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class UploadFileInfoController : BaseAdminController
    {
        private readonly IUploadFileInfoService _UploadFileInfoService;

        public UploadFileInfoController(IUploadFileInfoService UploadFileInfoService)
        {
            _UploadFileInfoService = UploadFileInfoService;
        }
        [HttpPost]
        public async Task<string> UploadImageAsync()
        {
            try
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                string sFileName = file.FileName;
                long size = file.Length;
                string sFileType = Path.GetExtension(sFileName.Trim()).ToUpper();
                if (sFileType == ".JPG" || sFileType == ".PNG" || sFileType == ".GIF" || sFileType == ".JPEG" || sFileType == ".BMP")
                {
                    //小于10MB
                    if (size < 10485760)
                    {
                        //添加文件
                        UploadFileInfo entityUploadFileInfo = await _UploadFileInfoService.AppendFileAsync(file, User.Identity.Name);
                        return JsonHelper.ObjectToJSON(new { code = 0, msg = "上传成功", data = new { src = entityUploadFileInfo.SrelativePath, Uid = entityUploadFileInfo.Uid.ToString() } });
                    }
                    else
                    {
                        return JsonHelper.ObjectToJSON(new { code = 1, msg = "上传失败!图片不能大于10MB", });
                    }
                }
                else
                {
                    return JsonHelper.ObjectToJSON(new { code = 1, msg = "上传失败!格式不符合!", });
                }
            }
            catch (System.Exception ex)
            {
                return JsonHelper.ObjectToJSON(new { code = 1, msg = ex.Message, });
            }
        }
    }
}