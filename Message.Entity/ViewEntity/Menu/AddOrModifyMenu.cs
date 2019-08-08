using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Entity.ViewEntity.Menu
{
    public class AddOrModifyMenu
    {
        public int Id { get; set; }
        public int IparentId { get; set; }
        public string Sname { get; set; }
        public string SiconUrl { get; set; }
        public string SlinkUrl { get; set; }
        public int Isort { get; set; }
        public bool? Bdisplay { get; set; }
        public string Sremarks { get; set; }
        public List<int> lstRoleId { get; set; }
    }
}
