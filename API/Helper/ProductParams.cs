using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public class ProductParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public int? ByBrand { get; set; }
        public int? ByType { get; set; }
        public string Search { get; set; }
    }
}
