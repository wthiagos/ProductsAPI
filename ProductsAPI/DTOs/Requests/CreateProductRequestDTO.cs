using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsAPI.DTOs.Requests;

public class CreateProductRequestDTO
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
    
    [Required]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}