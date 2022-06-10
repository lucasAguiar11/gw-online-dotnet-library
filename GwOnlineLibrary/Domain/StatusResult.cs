using System.Text.Json.Serialization;

namespace GwOnlineLibrary.Domain;

public class StatusResult
{
    /// <summary>
    /// Answer Status
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    /// Response Code
    /// </summary>
    [JsonPropertyName("situation")]
    public string Situation { get; set; }

    /// <summary>
    ///  Transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Transaction date
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Transaction receipt
    /// </summary>
    [JsonPropertyName("receipt")]
    public string Receipt { get; set; }
}