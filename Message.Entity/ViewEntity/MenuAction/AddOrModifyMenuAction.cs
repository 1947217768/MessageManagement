using System.Collections.Generic;

namespace Message.Entity.ViewEntity.MenuAction
{
    public class AddOrModifyMenuAction
    {
        public int Id { get; set; }
        public string Sremarks { get; set; }
        public int ImenuId { get; set; }
        public int IactionId { get; set; }
        public string Sexplain { get; set; }
        public bool? BisValid { get; set; }
    }
}
