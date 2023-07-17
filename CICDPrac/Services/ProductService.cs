using CICDPrac.Dtos;
using CICDPrac.Interfaces.repository;
using CICDPrac.Interfaces.service;
using CICDPrac.Models;

namespace CICDPrac.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product?> GetById(string id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            if (await _productRepository.CreateProduct(createProductDto) == 0)
            {
                throw new Exception("新增失敗");
            }
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (await _productRepository.UpdateProduct(updateProductDto) == 0)
            {
                throw new Exception("更新失敗");
            }
        }

        public async Task DeleteProduct(string id)
        {
            if (await _productRepository.DeleteProduct(id) == 0)
            {
                throw new Exception("刪除失敗");
            }
        }
    }
}

