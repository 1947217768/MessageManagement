using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Entity.Mapping
{
    public class FieldRelation : BaseEntity
    {
        public int IprimarykeyId { get; set; }
        public int IforeignkeyId { get; set; }
    }
}
