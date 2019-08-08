using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Entity.ViewEntity.UserInfo
{
    public class PersonalInfo : AddOrModifyUserInfo
    {
        /// <summary>
        /// 头像路径
        /// </summary>
        public string sAvatar { get; set; }
        public Guid Uid { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string SoldPassWord { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string SnewPassWord { get; set; }
        /// <summary>
        /// 确认新密码
        /// </summary>
        public string SconfirmPassWord { get; set; }
    }
}
