using Message.Entity.Mapping;
using Message.Entity.Redis;
using Message.IService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Message.UI.SignalR
{
    public class SignalRHelper : Hub
    {
        private readonly IMemoService _memoService;
        public SignalRHelper(IMemoService memoService)
        {
            _memoService = memoService;
        }
        public async Task SendMessage(string message)
        {
            int iUserId = Convert.ToInt32(Context.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            string sGroupName = "WebSocket_" + Context.User.Identity.Name + "_" + iUserId;

            Memo entityUserMemo = await RedisMethod.GetUserMemoAsync(sGroupName, -1, () => GetUserMemo(iUserId));
            entityUserMemo.Scontent = message;
            RedisMethod.SetUserMemo(sGroupName, entityUserMemo, -1);
            await Clients.Group(sGroupName).SendAsync("ReceiveMessage", message);
            //await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public override Task OnConnectedAsync()
        {
            int iUserId = Convert.ToInt32(Context.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            string sGroupName = "WebSocket_" + Context.User.Identity.Name + "_" + iUserId;
            Groups.AddToGroupAsync(Context.ConnectionId, sGroupName);
            return base.OnConnectedAsync();
        }
        public async Task<Memo> GetUserMemo(int iUserId)
        {
            Memo enttiyMemo = _memoService.Select(new Memo() { iUserId = iUserId });
            if (enttiyMemo == null)
            {
                enttiyMemo = new Memo() { iUserId = iUserId };
                await _memoService.AppendAsync(enttiyMemo, Context.User.Identity.Name);
            }
            return enttiyMemo;
        }
    }
}
