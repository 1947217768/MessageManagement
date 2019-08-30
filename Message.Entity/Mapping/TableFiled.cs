using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Entity.Mapping
{
    public class TableFiled : BaseEntity
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string SfiledName { get; set; }
        /// <summary>
        /// 表Id
        /// </summary>
        public int IdataTableId { get; set; }
        /// <summary>
        /// 数据类型Id
        /// </summary>
        public int IdataTypeId { get; set; }
        /// <summary>
        /// 是否为空
        /// </summary>
        public bool BisEmpty { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public int ImaxLength { get; set; }
    }
}
