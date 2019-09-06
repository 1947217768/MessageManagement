using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Message.Entity.Mapping
{
    public class MenuAction
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Sremarks { get; set; }
        [MaxLength(50), Required]
        public string Screater { get; set; }
        public DateTime? TcreateTime { get; set; }
        [MaxLength(50), Required]
        public string Smodifier { get; set; }
        public DateTime? TmodifyTime { get; set; }
        public int ImenuId { get; set; }
        public int IactionId { get; set; }
        [MaxLength(100)]
        public string Sexplain { get; set; }
        public bool? BisValid { get; set; }
    }
}
