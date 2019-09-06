using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Entity.ViewEntity.MenuAction
{
    public class ViewMenuAction : Mapping.MenuAction
    {
        public string SmenuName { get; set; }
        public string ScontrollerName { get; set; }
        public string SactionName { get; set; }
    }
}
