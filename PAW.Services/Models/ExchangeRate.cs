using System.Text.Json.Serialization;

namespace PAW.Services.Models;

public class ExchangeRate
{
    [JsonPropertyName("compra")]
    public decimal Buy { get; set; }
    [JsonPropertyName("venta")]
    public decimal Sell { get; set; }
    [JsonPropertyName("fecha")]
    public string Date { get; set; }
}
