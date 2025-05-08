using ProductsAPI.DTOs;
using ProductsAPI.DTOs.Requests;

namespace ProductsAPI.Interfaces;

public interface IProductRepository
{
    ProductDTO? GetProductById(int id);
    List<ProductDTO> GetAllProducts();
    void CreateProduct(CreateProductRequestDTO product);
    void UpdateProduct(int id, UpdateProductRequestDTO product);
    bool DeleteProduct(int id);
}