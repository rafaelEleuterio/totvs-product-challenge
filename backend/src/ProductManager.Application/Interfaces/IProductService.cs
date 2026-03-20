using ProductManager.Application.DTOs;

namespace ProductManager.Application.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task<ProductDto> CreateAsync(ProductDto dto);
    Task UpdateAsync(Guid id, ProductDto dto);
    Task DeleteAsync(Guid id);
}
