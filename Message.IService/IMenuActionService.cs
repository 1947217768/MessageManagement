using Message.Core.Models;
using Message.Entity.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.IService
{
    public interface IMenuActionService
    {
        PageInfo<MenuAction> GetPageList(PageInfo<MenuAction> pageInfo, MenuAction oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null);
        bool DeleteRange(int[] arrId, string sOperator);
    }
}