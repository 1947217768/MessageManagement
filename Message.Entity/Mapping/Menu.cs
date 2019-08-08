using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Message.Entity.Mapping
{
    public partial class Menu
    {
        public int Id { get; set; }
        [Required]
        public int IparentId { get; set; }
        public string Sname { get; set; }
        public string SiconUrl { get; set; }
        public string SlinkUrl { get; set; }
        public int Isort { get; set; }
        public bool? Bdisplay { get; set; }
        public string Sremarks { get; set; }
        public string Screater { get; set; }
        public DateTime? TcreateTime { get; set; }
        public string Smodifier { get; set; }
        public DateTime? TmodifyTime { get; set; }
    }
}
