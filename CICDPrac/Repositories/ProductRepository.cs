using CICDPrac.Contexts;
using CICDPrac.Dtos;
using CICDPrac.Interfaces.repository;
using CICDPrac.Models;
using Microsoft.EntityFrameworkCore;

namespace CICDPrac.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PracticeContext _ctx;

        public ProductRepository(PracticeContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _ctx.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetById(string id)
        {
            return await _ctx.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = createProductDto.Name,
                Price = createProductDto.Price
            };

            await _ctx.Products.AddAsync(product);
            return await _ctx.SaveChangesAsync();
        }

        public async Task<int> UpdateProduct(UpdateProductDto updateProductDto)
        {
            return await _ctx.Products.Where(p => p.Id == updateProductDto.Id).ExecuteUpdateAsync(
                s => s.SetProperty(p => p.Name, p => updateProductDto.Name)
                      .SetProperty(p => p.Price, p => updateProductDto.Price));
        }

        public async Task<int> DeleteProduct(string id)
        {
            return await _ctx.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}

