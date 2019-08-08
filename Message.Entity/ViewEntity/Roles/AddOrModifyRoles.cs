using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Entity.ViewEntity.Roles
{
    public class AddOrModifyRoles
    {

        public int Id { get; set; }
        public string SroleName { get; set; }
        public string Sremarks { get; set; }
        public List<int> lstUserId { get; set; }
        public List<int> lstMenuId { get; set; }
    }
}
