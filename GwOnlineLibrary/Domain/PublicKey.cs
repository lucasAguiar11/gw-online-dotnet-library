using System.Text.Json.Serialization;

namespace GwOnlineLibrary.Domain;

internal class PublicKey
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }
    
    [JsonPropertyName("publicKey")]
    public string Key { get; set; }
}