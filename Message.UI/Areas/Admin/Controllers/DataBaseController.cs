using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class DataBaseController : BaseAdminController
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly ISystemActionService _systemActionService;

        public DataBaseController(IDataBaseService dataBaseService, ISystemActionService systemActionService)
        {
            _dataBaseService = dataBaseService;
            _systemActionService = systemActionService;
        }
        public string LoadData(PageInfo<DataBase> pageInfo, DataBase oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_dataBaseService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index(int iPageId)
        {
            return List(iPageId);
        }
        public IActionResult AddOrModify(int iPageId)
        {
            return Edit(iPageId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync([FromForm]DataBase model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.SdataBaseName))
                    {
                        if (await _dataBaseService.AddOrModifyDataBaseAsync(model, User.Identity.Name) != null)
                        {
                            baseResult.Code = 0;
                            baseResult.Msg = "操作成功!";
                        }
                        else
                        {
                            baseResult.Code = 1;
                            baseResult.Msg = "操作失败!";
                        }
                    }
                    else
                    {
                        baseResult.Code = 3;
                        baseResult.Msg = "数据库名称不能为空!";
                    }
                }
            }
            catch (Exception ex)
            {
                baseResult.Code = 3;
                baseResult.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string DeleteRange(int[] arrId)
        {
            BaseResult baseResult = new BaseResult();
            if (_dataBaseService.DeleteRange(arrId, User.Identity.Name))
            {
                baseResult.Code = 0;
                baseResult.Msg = "删除成功!";
            }
            else
            {
                baseResult.Code = 1;
                baseResult.Msg = "删除失败!";
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }
    }
}