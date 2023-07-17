using CICDPrac.Dtos;
using CICDPrac.Models;

namespace CICDPrac.Interfaces.repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();

        public Task<Product?> GetById(string id);

        public Task<int> CreateProduct(CreateProductDto createProductDto);

        public Task<int> UpdateProduct(UpdateProductDto updateProductDto);

        public Task<int> DeleteProduct(string id);
    }
}

