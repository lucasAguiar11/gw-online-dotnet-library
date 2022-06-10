using System.Text.Json.Serialization;

namespace GwOnlineLibrary.Domain;

public class CancellationResult
{
    /// <summary>
    /// Answer status
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }
    
    /// <summary>
    /// Answer message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Original transaction ID (available for approved cancellation)
    /// </summary>
    [JsonPropertyName("originalTid")]
    public string OriginalTid { get; set; }

    /// <summary>
    /// Process details (available for declined cancellation)
    /// </summary>
    [JsonPropertyName("details")]
    public string Details { get; set; }
}