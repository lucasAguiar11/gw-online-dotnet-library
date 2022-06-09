using System.Text.Json.Serialization;

namespace GwOnlineLibrary.Domain;

public class TransactionResult
{
    /// <summary>
    /// Answer Status
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    /// Response Code
    /// </summary>
    [JsonPropertyName("cod")]
    public string Code { get; set; }

    /// <summary>
    /// Answer Message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Transaction ID (available for approved transaction)
    /// </summary>
    [JsonPropertyName("tid")]
    public string Tid { get; set; }

    /// <summary>
    /// Process detail (available for declined transaction)
    /// </summary>
    [JsonPropertyName("details")]
    public string Details { get; set; }
}