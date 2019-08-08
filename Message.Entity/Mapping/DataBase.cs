using System;
using System.Collections.Generic;

namespace Message.Entity.Mapping
{
    public partial class DataBase
    {
        public int Id { get; set; }
        public string SdataBaseName { get; set; }
        public string Sremarks { get; set; }
        public string Screater { get; set; }
        public DateTime? TcreateTime { get; set; }
        public string Smodifier { get; set; }
        public DateTime? TmodifyTime { get; set; }
    }
}
