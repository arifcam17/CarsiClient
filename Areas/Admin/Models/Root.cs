using System.Text.Json.Serialization;

namespace CarsiClient.Areas.Admin.Models
{
    public class Root<T>
    {
        [JsonPropertyName("Data")]
        public T Data { get; set; }

        [JsonPropertyName("Succeed")]
        public bool Succeed { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Error")]
        public string Error { get; set; }
    }
}
