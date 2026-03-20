using ProductManager.Application.DTOs;
using ProductManager.Application.Interfaces;
using ProductManager.Domain.Entities;

namespace ProductManager.Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        });
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }

    public async Task<ProductDto> CreateAsync(ProductDto dto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }

    public async Task UpdateAsync(Guid id, ProductDto dto)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return;

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;

        await _repository.UpdateAsync(product);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return;

        await _repository.DeleteAsync(product);
        await _repository.SaveChangesAsync();
    }
}
