using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.Redis;
using Message.Entity.ViewEntity.DataTable;
using Message.IService;
using Message.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.Areas.Admin.Controllers
{
    public class MemoController : BaseAdminController
    {
        private readonly IMemoService _memoService;
        public MemoController(IMemoService memoService)
        {
            _memoService = memoService;
        }
        public async Task<IActionResult> IndexAsync(int iPageId)
        {
            int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            //Memo entityMemo = await _memoService.SelectAsync(new Memo() { iUserId = iUserId });
            string sGroupName = "WebSocket_" + User.Identity.Name + "_" + iUserId;
            Memo entityUserMemo = await RedisMethod.GetUserMemoAsync(sGroupName, -1, () => GetUserMemo(iUserId));
            if (entityUserMemo == null)
            {
                entityUserMemo = new Memo() { iUserId = iUserId };
                await _memoService.AppendAsync(entityUserMemo, User.Identity.Name);
            }
            ViewBag.Scontent = entityUserMemo.Scontent;
            return Empty(iPageId);
        }
        public async Task<Memo> GetUserMemo(int iUserId)
        {
            Memo enttiyMemo = _memoService.Select(new Memo() { iUserId = iUserId });
            if (enttiyMemo == null)
            {
                enttiyMemo = new Memo() { iUserId = iUserId };
                await _memoService.AppendAsync(enttiyMemo, User.Identity.Name);
            }
            return enttiyMemo;
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<bool> Save(string sContent)
        {
            try
            {
                int iUserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                Memo entityMemo = await _memoService.SelectAsync(new Memo() { iUserId = iUserId });
                if (entityMemo == null)
                {
                    entityMemo = new Memo() { iUserId = iUserId, Scontent = sContent };
                    await _memoService.AppendAsync(entityMemo, User.Identity.Name);
                }
                else
                {
                    entityMemo.Scontent = sContent;
                    _memoService.Update(entityMemo, User.Identity.Name);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}