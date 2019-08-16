using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Menu;
using Message.IService;
using Message.UI.Areas.Admin.Validation.Menu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class MenuController : BaseAdminController
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public string LoadData(PageInfo<Menu> pageInfo, Menu oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_menuService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index()
        {
            return List();
        }
        public async Task<IActionResult> AddOrModifyAsync()
        {
            ViewBag.lstParentMenu = await _menuService.GetMenuListAsync(new Menu() { IparentId = -1 });
            return base.Edit();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> AddOrModifyAsync([FromForm]AddOrModifyMenu model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {

                    AddOrModifyMenuValidation validationRules = new AddOrModifyMenuValidation();
                    ValidationResult validationResilt = await validationRules.ValidateAsync(model);
                    if (validationResilt.IsValid)
                    {
                        Menu entityMenu = await _menuService.AddOrModifyMenuAsync(model, User.Identity.Name);
                        if (entityMenu != null)
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
                        baseResult.Msg = validationResilt.ToString("<br/>");
                    }
                }
            }
            catch (Exception ex)
            {
                baseResult.Code = 4;
                baseResult.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<BaseResult> ChangeMenuState(ChangeMenuState model)
        {
            BaseResult baseResult = new BaseResult();

            try
            {
                if (await _menuService.ChangeMenuStateAsync(model, User.Identity.Name) != null)
                {
                    baseResult.Code = 0;
                    baseResult.Msg = "修改成功!";
                }
                else
                {

                    baseResult.Code = 2;
                    baseResult.Msg = "修改失败!";
                }
            }
            catch (Exception ex)
            {
                baseResult.Code = 3;
                baseResult.Msg = ex.Message;
            }
            return baseResult;
        }

        [HttpGet]
        public async Task<string> GetMenuListAsync()
        {
            List<Menu> lstMenu = await _menuService.GetMenuListAsync();
            List<ViewSelect> lstViewSelect = new List<ViewSelect>();
            if (lstMenu?.Count > 0)
            {
                foreach (Menu entityMenu in lstMenu)
                {
                    lstViewSelect.Add(new ViewSelect() { id = entityMenu.Id, name = entityMenu.Sname });
                }
            }
            return JsonHelper.ObjectToJSON(lstViewSelect);
        }
        public string DeleteRange(int[] arrId)
        {
            BaseResult baseResult = new BaseResult();
            if (_menuService.DeleteRange(arrId, User.Identity.Name))
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