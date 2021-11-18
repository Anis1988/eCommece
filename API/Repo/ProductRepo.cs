using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Helper;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _context;
        public readonly IMapper _mapper ;
        public ProductRepo(StoreContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<PagedList<ProductDto>> GetProductsAsync(ProductParams productParams)
        {
            var products  =  _context.Products.AsQueryable();
            if (productParams.ByBrand.HasValue )
            {
                products = products.Where(x => x.ProductBrandId == productParams.ByBrand).AsQueryable();
            };
            if (productParams.ByType.HasValue)
            {
                products = products.Where(x => x.ProductTypeId == productParams.ByType).AsQueryable();
            };
            if (!string.IsNullOrEmpty(productParams.Search))
            {
                products = products.Where(x =>x.Name.ToLower().Contains(productParams.Search.ToLower())).AsQueryable();
            }

            products = productParams.OrderBy switch
            {
                "byName" => products.OrderBy(n =>n.Name).Include(p =>p.ProductBrand).Include(p =>p.ProductType),
                "byPriceAsc" =>  products.OrderBy(p => p.Price).Include(p => p.ProductBrand).Include(p => p.ProductType),
                "byPriceDesc" => products.OrderByDescending(p => p.Price).Include(p => p.ProductBrand).Include(p => p.ProductType),
                _ => products.Include(p => p.ProductBrand).Include(p => p.ProductType)

            };


            return  await PagedList<ProductDto>.CreateAsync(products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                productParams.PageNumber,productParams.PageSize);
        }
        public async Task<ProductDto> GetSingleProductAsync(int id)
        {
            return await _context.Products.Where(x =>x.Id ==id).ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .Include(t => t.ProductType)
            .Include(b => b.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<ProductBrand>> GetProductsBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductsTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
