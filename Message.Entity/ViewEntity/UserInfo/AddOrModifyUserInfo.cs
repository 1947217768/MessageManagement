using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.Entity.ViewEntity.UserInfo
{
    public class AddOrModifyUserInfo
    {
        public int Id { get; set; }
        public string SloginName { get; set; }
        public string SloginPwd { get; set; }
        public string SuserName { get; set; }
        public string SuserPhone { get; set; }
        public bool BisLock { get; set; }
        public string SuserEmail { get; set; }
        public string Sremarks { get; set; }
        public List<int> lstRoleId { get; set; }
    }
}
