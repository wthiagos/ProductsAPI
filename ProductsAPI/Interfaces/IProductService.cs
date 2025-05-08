using ProductsAPI.DTOs.Requests;
using ProductsAPI.DTOs.Responses;

namespace ProductsAPI.Interfaces;

public interface IProductService
{
    CreateProductResponseDTO GetProductById(int id);
    List<CreateProductResponseDTO> GetAllProducts();
    void CreateProduct(CreateProductRequestDTO product);
    void UpdateProduct(int id, UpdateProductRequestDTO product);
    bool DeleteProduct(int id);
}