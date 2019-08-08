using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Message.Entity.Mapping
{
    [Table("UserInfo")]
    public class UserInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 登陆名
        /// </summary>
        [MaxLength(30), Required]
        public string SloginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(100), Required]
        public string SloginPwd { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(20), Required]
        public string SuserName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(50), Required]
        public string SuserPhone { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool? BisLock { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(50), Required]
        public string SuserEmail { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        [MaxLength(64)]
        public string SloginLastIp { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? TloginLastTime { get; set; }
        /// <summary>
        /// 头像文件Id
        /// </summary>
        [Required]
        public int IfileInfoId { get; set; } = 0;
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Sremarks { get; set; }
        [MaxLength(50)]
        public string Screater { get; set; }
        public DateTime? TcreateTime { get; set; }
        [MaxLength(50)]
        public string Smodifier { get; set; }
        public DateTime? TmodifyTime { get; set; }
    }
}
