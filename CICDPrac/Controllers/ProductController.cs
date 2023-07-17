using CICDPrac.Dtos;
using CICDPrac.Interfaces.service;
using CICDPrac.Models;
using Microsoft.AspNetCore.Mvc;

namespace CICDPrac.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet(nameof(GetById))]
        public async Task<Product?> GetById(string id)
        {
            return await _productService.GetById(id);
        }

        [HttpPost(nameof(CreateProduct))]
        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProduct(createProductDto);
        }

        [HttpPatch(nameof(UpdateProduct))]
        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProduct(updateProductDto);
        }

        [HttpDelete(nameof(DeleteProduct))]
        public async Task DeleteProduct(string id)
        {
            await _productService.DeleteProduct(id);
        }
    }
}

