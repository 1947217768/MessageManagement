using Message.Entity.ViewEntity.MenuAction;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class MenuActionController : BaseAdminController
    {
        private readonly IMenuActionService _menuActionService;

        public MenuActionController(IMenuActionService menuActionService)
        {
            _menuActionService = menuActionService;
        }
        public string LoadData(PageInfo<ViewMenuAction> pageInfo, ViewMenuAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_menuActionService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
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
        public async Task<string> AddOrModifyAsync([FromForm]AddOrModifyMenuAction model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    //验证规则  Validation
                    //if (!string.IsNullOrWhiteSpace(model.StypeName))
                    //{
                    if (await _menuActionService.AddOrModifyMenuActionAsync(model, User.Identity.Name) != null)
                    {
                        baseResult.Code = 0;
                        baseResult.Msg = "操作成功!";
                    }
                    else
                    {
                        baseResult.Code = 1;
                        baseResult.Msg = "操作失败!";
                    }
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
            if (_menuActionService.DeleteRange(arrId, User.Identity.Name))
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
