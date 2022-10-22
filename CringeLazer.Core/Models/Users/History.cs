using System.Text.Json.Serialization;
using CringeLazer.Core.Converters;

namespace CringeLazer.Core.Models.Users;

/// <summary>
///  The thing below is a complete haram. The only thing why it's here is because System.Text.Json have no global settings to set default converters for types and naming strategy as well.
/// </summary>
public class History
{
    [JsonPropertyName("date")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}
