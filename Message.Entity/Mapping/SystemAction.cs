using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Message.Entity.Mapping
{
    public class SystemAction : BaseEntity
    {
        [MaxLength(200)]
        public string SactionName { get; set; }
        public int IcontrollerId { get; set; }
    }
}
