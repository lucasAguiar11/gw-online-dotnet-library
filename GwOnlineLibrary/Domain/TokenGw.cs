using System.Text.Json.Serialization;

namespace GwOnlineLibrary.Domain;

internal class TokenGw
{
    
    [JsonPropertyName("status")]
    public bool Status { get; set; }
    
    [JsonPropertyName("token")]
    public string Token { get; set; }
}