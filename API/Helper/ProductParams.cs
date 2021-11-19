

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
