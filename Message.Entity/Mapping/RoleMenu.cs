using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Message.Entity.Mapping
{
    public partial class RoleMenu
    {
        public int Id { get; set; }
        public int IroleId { get; set; }
        public int ImenuId { get; set; }

        [MaxLength(200)]
        public string Sremarks { get; set; }
        public string Screater { get; set; }
        public DateTime? TcreateTime { get; set; }
        public string Smodifier { get; set; }
        public DateTime? TmodifyTime { get; set; }
    }
}
