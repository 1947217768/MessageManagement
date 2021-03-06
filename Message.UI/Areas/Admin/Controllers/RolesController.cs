﻿using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.Redis;
using Message.Entity.ViewEntity;
using Message.Entity.ViewEntity.Roles;
using Message.IService;
using Message.UI.Areas.Admin.Validation.Roles;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class RolesController : BaseAdminController
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        public string LoadData(PageInfo<Roles> pageInfo, Roles oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_rolesService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index(int iPageId)
        {
            return List(iPageId);
        }
        public IActionResult AddOrModify(int iPageId)
        {
            return base.Edit(iPageId);
        }
        public string GetRoleList()
        {
            List<ViewSelect> lstViewSelect = new List<ViewSelect>();
            List<Roles> lstRoles = RedisMethod.GetSystemRoles(-1, () => _rolesService.GetRolesList());
            if (lstRoles?.Count > 0)
            {
                foreach (Roles entityRoles in lstRoles)
                {
                    ViewSelect entity = new ViewSelect();
                    entity.id = entityRoles.Id;
                    entity.name = entityRoles.SroleName;
                    lstViewSelect.Add(entity);
                }
            }
            return JsonHelper.ObjectToJSON(lstViewSelect);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync(AddOrModifyRoles model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    AddOrModifyRolesValidation validationRules = new AddOrModifyRolesValidation();
                    ValidationResult validationResilt = await validationRules.ValidateAsync(model);
                    if (validationResilt.IsValid)
                    {
                        if (await _rolesService.AddOrModifyAsync(model, User.Identity.Name) != null)
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
                        baseResult.Msg = validationResilt.ToString("<br>");
                    }

                }
            }
            catch (System.Exception ex)
            {
                baseResult.Code = 4;
                baseResult.Msg = ex.Message;
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string DeleteRange(int[] arrId)
        {
            BaseResult baseResult = new BaseResult();
            if (_rolesService.DeleteRange(arrId, User.Identity.Name))
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