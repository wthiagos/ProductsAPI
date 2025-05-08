using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs.Requests;
using ProductsAPI.DTOs.Responses;
using ProductsAPI.Exceptions;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : Controller
{
    [HttpGet]
    public ActionResult<List<CreateProductResponseDTO>> GetAllProducts()
    {
        return Ok(productService.GetAllProducts());
    }
    
    [HttpGet("${id}")]
    public ActionResult<CreateProductResponseDTO> GetProductById([FromRoute] int id)
    {
        try
        {
            return Ok(productService.GetProductById(id));
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public CreatedResult CreateProduct([FromBody]CreateProductRequestDTO product)
    {
        productService.CreateProduct(product);
        return Created();
    }
    
    [HttpPut("${id}")]
    public ActionResult<CreateProductResponseDTO> UpdateProduct([FromRoute]int id, [FromBody]UpdateProductRequestDTO product)
    {
        try
        {
            productService.UpdateProduct(id, product);
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("${id}")]
    public ActionResult<CreateProductResponseDTO> DeleteProduct([FromRoute]int id)
    {
        try
        {
            productService.DeleteProduct(id);
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
    }
}