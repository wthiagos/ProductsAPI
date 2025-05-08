using ProductsAPI.DTOs;
using ProductsAPI.DTOs.Requests;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Repositories;

public class ProductRepository(): IProductRepository
{
    private readonly List<ProductDTO> _products = [];
    
    public ProductDTO? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public List<ProductDTO> GetAllProducts()
    {
        return _products;
    }

    public void CreateProduct(CreateProductRequestDTO product)
    {
        var newId = _products.Count + 1;
        
        _products.Add(new ProductDTO
        {
            Id = newId,
            Name = product.Name,
            Price = product.Price
        });
    }

    public void UpdateProduct(int id, UpdateProductRequestDTO product)
    {
       var productToUpdate = _products.First(p => p.Id == id);
       
       productToUpdate.Name = product.Name;
       productToUpdate.Price = product.Price;
       
       _products.Remove(productToUpdate);
       _products.Add(productToUpdate);
    }

    public bool DeleteProduct(int id)
    {
        var productToDelete = _products.FirstOrDefault(p => p.Id == id);

        if (productToDelete is null)
            return false;
        
        _products.Remove(productToDelete);
        
        return true;
    }
}