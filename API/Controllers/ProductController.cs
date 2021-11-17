using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo productRepo,IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductss([FromQuery]string info)
        {
            return  Ok (await _productRepo.GetProductsAsync(info));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            return Ok( await _productRepo.GetSingleProductAsync(id));

        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductssTypes()
        {
            return Ok(await _productRepo.GetProductsTypesAsync());
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductssBrands()
        {
            return Ok(await _productRepo.GetProductsBrandAsync());
        }
    }
}
