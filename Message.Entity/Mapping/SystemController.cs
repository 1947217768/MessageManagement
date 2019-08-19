using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Message.Entity.Mapping
{
    public class SystemController : BaseEntity
    {
        [MaxLength(100)]
        public string ScontrollerName { get; set; }
    }
}
