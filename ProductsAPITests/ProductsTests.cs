using ProductsAPI.Controllers;
using ProductsAPI.DTOs.Requests;
using ProductsAPI.Interfaces;
using ProductsAPI.Repositories;
using ProductsAPI.Services;

namespace ProductsAPITests;

public class Tests
{
    private ProductsController _productsController;
    private ProductService _productService;
    private IProductRepository _productRepository;
    
    private readonly CreateProductRequestDTO _createProductRequest = new CreateProductRequestDTO
    {
        Name = "Mouse",
        Price = 100
    };

    [SetUp]
    public void Setup()
    {
        _productRepository = new ProductRepository();
        _productService = new ProductService(_productRepository);
        _productsController = new ProductsController(_productService);
    }

    [Test]
    public void CreateProductTestSuccess()
    {
        _productService.CreateProduct(_createProductRequest);
    }
    
    
    [Test]
    public void GetProductByIdTestError()
    {
        _productsController.GetProductById(0);
    }

    [TearDown]
    public void TearDown()
    {
        _productsController.Dispose();
    }
}