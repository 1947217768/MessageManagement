using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Message.UI.Models;
using Message.Entity.Mapping;
using Message.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Message.UI.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public abstract class BaseAdminController : Controller
    {
        /// <summary>
        /// 读取appsettings.json配置文件
        /// </summary>
        /// <param name="sKey">key</param>
        /// <param name="appsettings">路径默认appsettings.json</param>
        /// <returns>值</returns>
        public string GetJsonValue(string sKey, string sPath = "appsettings.json")
        {
            var builder = new ConfigurationBuilder().AddJsonFile(sPath);
            var configurationRoot = builder.Build();
            string sValue = configurationRoot.GetSection(sKey).Value.ToString();
            return sValue;
        }
        public IActionResult List()
        {
            ViewData["iPageType"] = 0;
            return View();
        }
        public IActionResult Edit()
        {
            ViewData["iPageType"] = 1;
            return View();
        }
    }
}
