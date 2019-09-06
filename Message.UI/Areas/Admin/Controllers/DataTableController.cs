using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.DataTable;
using Message.IService;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class DataTableController : BaseAdminController
    {
        private readonly IDataTableService _dataTableService;
        private readonly IDataBaseService _dataBaseService;
        public DataTableController(IDataTableService dataTableService, IDataBaseService dataBaseService)
        {
            _dataTableService = dataTableService;
            _dataBaseService = dataBaseService;
        }
        public string LoadData(PageInfo<ViewDataTable> pageInfo, ViewDataTable oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_dataTableService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public async Task<IActionResult> IndexAsync(int iPageId)
        {
            List<DataBase> lstDataBase = await _dataBaseService.SelectALLAsync();
            ViewBag.lstDataBase = lstDataBase;
            return List(iPageId);
        }
        public async Task<IActionResult> AddOrModifyAsync(int iPageId)
        {
            List<DataBase> lstDataBase = await _dataBaseService.SelectALLAsync();
            ViewBag.lstDataBase = lstDataBase;
            return Edit(iPageId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync([FromForm]DataTable model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.StableName) && model.IdataBaseId > 0)
                    {
                        if (await _dataTableService.AddOrModifyDataTableAsync(model, User.Identity.Name) != null)
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
                        baseResult.Msg = "控制器名称不能为空!";
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
            if (_dataTableService.DeleteRange(arrId, User.Identity.Name))
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