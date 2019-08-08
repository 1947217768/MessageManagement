using System;
using System.ComponentModel.DataAnnotations;
namespace Message.Entity.Mapping
{
    public class UploadFileInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid Uid { get; set; }
        /// <summary>
        /// 原文件名
        /// </summary>
        [MaxLength(100), Required]
        public string SoriginalFileName { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [MaxLength(100), Required]
        public string SfileName { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [MaxLength(30), Required]
        public string SfileType { get; set; }
        /// <summary>
        /// 文件绝对路径
        /// </summary>
        [MaxLength(500), Required]
        public string SfilePath { get; set; }
        /// <summary>
        /// 文件相对路径
        /// </summary>
        [MaxLength(500), Required]
        public string SrelativePath { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [Required]
        public int Isize { get; set; }
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
