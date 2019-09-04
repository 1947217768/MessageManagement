using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.TableFiled;
using Message.IService;
using Message.UI.Areas.Admin.Validation.TableFiled;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class TableFiledController : BaseAdminController
    {
        private readonly ITableFiledService _tableFiledService;
        private readonly IDataBaseService _dataBaseService;
        private readonly IDataTypeService _dataTypeService;
        private readonly IDataTableService _dataTableService;


        public TableFiledController(ITableFiledService TableFiledService, IDataBaseService dataBaseService, IDataTypeService dataTypeService, IDataTableService dataTableService)
        {
            _tableFiledService = TableFiledService;
            _dataBaseService = dataBaseService;
            _dataTypeService = dataTypeService;
            _dataTableService = dataTableService;
        }
        public string LoadData(PageInfo<ViewTableFiled> pageInfo, ViewTableFiled oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_tableFiledService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index()
        {
            return List();
        }
        public async Task<IActionResult> AddOrModify()
        {
            List<DataTable> lstDataTable = await _dataTableService.SelectALLAsync();
            List<DataType> lstDataType = await _dataTypeService.SelectALLAsync();
            ViewBag.lstDataTable = lstDataTable;
            ViewBag.lstDataType = lstDataType;
            return Edit();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync([FromForm]TableFiled model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    TableFiledValidation validationFailure = new TableFiledValidation();
                    ValidationResult validationResult = await validationFailure.ValidateAsync(model);
                    if (validationResult.IsValid)
                    {
                        if (await _tableFiledService.AddOrModifyTableFiledAsync(model, User.Identity.Name) != null)
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
                        baseResult.Msg = validationResult.ToString("<br>");
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
            if (_tableFiledService.DeleteRange(arrId, User.Identity.Name))
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

        public async Task<IActionResult> TableInfo(int iTableId)
        {
            DataTable entityDataTable = await _dataTableService.SelectAsync(iTableId);
            if (entityDataTable != null)
            {
                DataBase entityDataBase = await _dataBaseService.SelectAsync(entityDataTable.IdataBaseId);
                if (entityDataBase != null)
                {
                    ViewBag.entityDataBase = entityDataBase;
                }
                List<ViewTableFiled> lstViewTableFiled = await _tableFiledService.GetViewTableInfoAsync(entityDataTable.Id);
                //生成Mapping映射类
                ViewBag.lstTableFiled = lstViewTableFiled;
                ViewBag.entityDataTable = entityDataTable;
            }
            return Empty();
        }
    }
}