using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(string info);
        Task<ProductDto> GetSingleProductAsync(int id);
        Task<IEnumerable<ProductType>> GetProductsTypesAsync();
        Task<IEnumerable<ProductBrand>> GetProductsBrandAsync();


    }
}
