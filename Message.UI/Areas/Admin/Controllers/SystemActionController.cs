using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.SystemAction;
using Message.IService;
using Message.UI.Areas.Admin.Validation.SystemAction;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class SystemActionController : BaseAdminController
    {
        private readonly ISystemActionService _systemActionService;
        private readonly ISystemControllerService _systemControllerService;


        public SystemActionController(ISystemActionService systemActionService, ISystemControllerService systemControllerService)
        {
            _systemActionService = systemActionService;
            _systemControllerService = systemControllerService;
        }
        public string LoadData(PageInfo<ViewSystemAction> pageInfo, ViewSystemAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_systemActionService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index(int iPageId)
        {
            return List(iPageId);
        }
        public async Task<IActionResult> AddOrModifyAsync(int iPageId)
        {
            List<SystemController> lstSystemController = await _systemControllerService.SelectALLAsync();
            ViewBag.lstSystemController = lstSystemController;
            return Edit(iPageId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync([FromForm]SystemAction model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    SystemActionValidation validationRules = new SystemActionValidation();
                    ValidationResult validationResult = await validationRules.ValidateAsync(model);
                    if (validationResult.IsValid)
                    {

                        if (await _systemActionService.AddOrModifySystemActionAsync(model, User.Identity.Name) != null)
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
            if (_systemActionService.DeleteRange(arrId, User.Identity.Name))
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