using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Helper;

namespace API.Interfaces
{
    public interface IProductRepo
    {
        Task<PagedList<ProductDto>> GetProductsAsync(ProductParams productParams);
        Task<ProductDto> GetSingleProductAsync(int id);
        Task<IEnumerable<ProductType>> GetProductsTypesAsync();
        Task<IEnumerable<ProductBrand>> GetProductsBrandAsync();


    }
}
