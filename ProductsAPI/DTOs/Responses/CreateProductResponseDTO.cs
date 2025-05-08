using System.Text.Json.Serialization;

namespace ProductsAPI.DTOs.Responses;

public class CreateProductResponseDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}