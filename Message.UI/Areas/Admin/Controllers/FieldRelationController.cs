using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class FieldRelationController : BaseAdminController
    {
        private readonly IFieldRelationService _FieldRelationService;
        private readonly ISystemActionService _systemActionService;

        public FieldRelationController(IFieldRelationService  FieldRelationService, ISystemActionService systemActionService)
        {
            _FieldRelationService = FieldRelationService;
            _systemActionService = systemActionService;
        }
        public string LoadData(PageInfo<FieldRelation> pageInfo, FieldRelation oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_FieldRelationService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
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
        public async Task<string> AddOrModifyAsync([FromForm]FieldRelation model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    //if (!string.IsNullOrWhiteSpace(model.ScontrollerName))
                    //{
                    //    if (await _FieldRelationService.AddOrModifyFieldRelationAsync(model, User.Identity.Name) != null)
                    //    {
                    //        baseResult.Code = 0;
                    //        baseResult.Msg = "操作成功!";
                    //    }
                    //    else
                    //    {
                    //        baseResult.Code = 1;
                    //        baseResult.Msg = "操作失败!";
                    //    }
                    //}
                    //else
                    //{
                    //    baseResult.Code = 3;
                    //    baseResult.Msg = "控制器名称不能为空!";
                    //}
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
            if (_FieldRelationService.DeleteRange(arrId, User.Identity.Name))
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