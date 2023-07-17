using CICDPrac.Dtos;
using CICDPrac.Models;

namespace CICDPrac.Interfaces.service
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();

        public Task<Product?> GetById(string id);

        public Task CreateProduct(CreateProductDto createProductDto);

        public Task UpdateProduct(UpdateProductDto updateProductDto);

        public Task DeleteProduct(string id);
    }
}

