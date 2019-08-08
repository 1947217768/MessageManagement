using System;
using System.Collections.Generic;

namespace Message.Core.Models
{
    public class PageInfo<TEntity>
    {

        public int code = 0;
        public int count { get; set; } = 0;
        public int limit { get; set; } = 10;
        public int page { get; set; } = 1;
        public IList<TEntity> data { get; set; }
        public override string ToString()
        {
            return $"code={code};count={count};pageSize={limit};pageNumber={page};";
        }
    }
}
