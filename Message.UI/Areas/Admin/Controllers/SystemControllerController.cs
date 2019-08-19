using FluentValidation.Results;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IService;
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
        public SystemControllerController(ISystemControllerService SystemControllerService)
        {
            _SystemControllerService = SystemControllerService;
        }
        public string LoadData(PageInfo<SystemController> pageInfo, SystemController oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return JsonHelper.ObjectToJSON(_SystemControllerService.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder));
        }
        public IActionResult Index()
        {
            return List();
        }
        public async Task<IActionResult> AddOrModifyAsync()
        {
            return base.Edit();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<BaseResult> ReflectionController()
        {
            BaseResult baseResult = new BaseResult();
            try
            {
                Assembly[] arrAssembly = AppDomain.CurrentDomain.GetAssemblies();
                List<MethodInfo> lstMethodInfoController = new List<MethodInfo>();
                for (int i = 0; i < arrAssembly.Length; i++)
                {
                    if (arrAssembly[i].GetName().Name.Equals("System.Web.Mvc"))
                    {
                        foreach (Type item in arrAssembly[i].GetModule("System.Web.Mvc.dll").GetTypes())
                        {
                            if (item.Name.Equals("Controller"))
                            {
                                lstMethodInfoController.AddRange(item.GetMethods());
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return baseResult;
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