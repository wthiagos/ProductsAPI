using ProductsAPI.DTOs.Requests;
using ProductsAPI.DTOs.Responses;
using ProductsAPI.Exceptions;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public CreateProductResponseDTO GetProductById(int id)
    {
        var product = productRepository.GetProductById(id);
        
        if (product is null) 
            throw new ProductNotFoundException("Product not found");
        
        return new CreateProductResponseDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public List<CreateProductResponseDTO> GetAllProducts()
    {
        var products = productRepository.GetAllProducts();

        return products
            .Select(p => new CreateProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            })
            .ToList();
    }

    public void CreateProduct(CreateProductRequestDTO product)
    {
        productRepository.CreateProduct(product);
    }

    public void UpdateProduct(int id, UpdateProductRequestDTO product)
    {
        var productExists = productRepository.GetProductById(id);
        
        if (productExists is null) 
            throw new ProductNotFoundException("Product not found");
        
        productRepository.UpdateProduct(id, product);
    }

    public bool DeleteProduct(int id)
    {
        var productExists = productRepository.GetProductById(id);
        
        if (productExists is null) 
            throw new ProductNotFoundException("Product not found");
        
        return productRepository.DeleteProduct(id);
    }
}