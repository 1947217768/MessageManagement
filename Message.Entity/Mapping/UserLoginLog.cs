using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Message.Entity.Mapping
{
    public class UserLoginLog
    {
        [Key]
        public int Id { get; set; }
        public int IuserId { get; set; }
        public int Icode { get; set; }
        public string Smsg { get; set; }
        public string SloginId { get; set; }
        public string Screater { get; set; }
        public DateTime? TcreateTime { get; set; }
        [MaxLength(50), Required]
        public string Smodifier { get; set; }
        public DateTime? TmodifyTime { get; set; }
    }
}
