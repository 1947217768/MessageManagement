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
    public class SystemControllerController : BaseAdminController
    {
        private readonly ISystemControllerService _SystemControllerService;
        private readonly ISystemActionService _systemActionService;

        public SystemControllerController(ISystemControllerService SystemControllerService, ISystemActionService systemActionService)
        {
            _SystemControllerService = SystemControllerService;
            _systemActionService = systemActionService;
        }
        public string LoadData(PageInfo<SystemController> pageInfo, SystemController oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_SystemControllerService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index()
        {
            return List();
        }
        public IActionResult AddOrModify()
        {
            return Edit();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CrossSiteScript]
        public async Task<string> AddOrModifyAsync([FromForm]SystemController model)
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ScontrollerName))
                    {
                        if (await _SystemControllerService.AddOrModifySystemControllerAsync(model, User.Identity.Name) != null)
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
        //[ValidateAntiForgeryToken]
        public async Task<string> ReflectionController()
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                List<SystemController> lstSystemController = new List<SystemController>();
                List<SystemAction> lstSystemAction = new List<SystemAction>();
                Assembly[] arrAssembly = AppDomain.CurrentDomain.GetAssemblies();
                List<MethodInfo> lstMethodInfoController = new List<MethodInfo>();
                for (int i = 0; i < arrAssembly.Length; i++)
                {
                    if (arrAssembly[i].GetName().Name.Equals("Microsoft.AspNetCore.Mvc.ViewFeatures"))
                    {
                        foreach (Type item in arrAssembly[i].GetModule("Microsoft.AspNetCore.Mvc.ViewFeatures.dll").GetTypes())
                        {
                            if (item.Name.Equals("Controller"))
                            {
                                lstMethodInfoController.AddRange(item.GetMethods());
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < arrAssembly.Length; i++)
                {
                    if (arrAssembly[i].GetName().Name.Equals("Message.UI"))
                    {
                        foreach (Type item in arrAssembly[i].GetModule("Message.UI.dll").GetTypes())
                        {
                            if (!string.IsNullOrWhiteSpace(item.Namespace))
                            {
                                if (item.Namespace.ToString().Equals("Message.UI.Areas.Admin.Controllers") && item.Name.EndsWith("Controller"))
                                {
                                    if (item.Name == "BaseAdminController")
                                    {
                                        continue;
                                    }
                                    SystemController entity = new SystemController()
                                    {
                                        ScontrollerName = item.Name.Replace("Controller", string.Empty)
                                    };
                                    lstSystemController.Add(entity);
                                    SystemController entitySystemController = await _SystemControllerService.SelectAsync(new SystemController() { ScontrollerName = entity.ScontrollerName });
                                    if (entitySystemController == null)
                                    {
                                        await _SystemControllerService.AppendAsync(entity, User.Identity.Name);
                                    }
                                    else
                                    {
                                        entity.Id = entitySystemController.Id;
                                    }
                                    foreach (MethodInfo entityMethodInfo in item.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                                    {
                                        if (!lstMethodInfoController.Exists(x => x.Name.Equals(entityMethodInfo.Name)))
                                        {
                                            SystemAction entitySystemAction = new SystemAction()
                                            {
                                                IcontrollerId = entity.Id,
                                                SactionName = entityMethodInfo.Name,
                                                SresultType = entityMethodInfo.ReturnType.Name
                                            };
                                            if (_systemActionService.Select(entitySystemAction) == null)
                                            {
                                                await _systemActionService.AppendAsync(entitySystemAction, User.Identity.Name);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                baseResult.Code = 0;
                baseResult.Msg = "操作成功!";
            }
            catch (Exception ex)
            {
                baseResult.Code = 3;
                baseResult.Msg = ex.Message;
                throw;
            }
            return JsonHelper.ObjectToJSON(baseResult);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<string> AddOrModifyAsync([FromForm]AddOrModifySystemController model)
        //{
        //    BaseResult baseResult = new BaseResult();
        //    try
        //    {
        //        if (model != null)
        //        {

        //            AddOrModifySystemControllerValidation validationRules = new AddOrModifySystemControllerValidation();
        //            ValidationResult validationResilt = await validationRules.ValidateAsync(model);
        //            if (validationResilt.IsValid)
        //            {
        //                SystemController entitySystemController = await _SystemControllerService.AddOrModifySystemControllerAsync(model, User.Identity.Name);
        //                if (entitySystemController != null)
        //                {
        //                    baseResult.Code = 0;
        //                    baseResult.Msg = "操作成功!";
        //                }
        //                else
        //                {
        //                    baseResult.Code = 1;
        //                    baseResult.Msg = "操作失败!";
        //                }
        //            }
        //            else
        //            {
        //                baseResult.Code = 3;
        //                baseResult.Msg = validationResilt.ToString("<br/>");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        baseResult.Code = 4;
        //        baseResult.Msg = ex.Message;
        //    }
        //    return JsonHelper.ObjectToJSON(baseResult);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string DeleteRange(int[] arrId)
        {
            BaseResult baseResult = new BaseResult();
            if (_SystemControllerService.DeleteRange(arrId, User.Identity.Name))
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