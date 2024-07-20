using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;

namespace CarsiClient.Areas.Admin.Models
{
    public class AddProduct
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

      

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("IsHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("Stock")]
        public int Stock { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }

      
    }
}

