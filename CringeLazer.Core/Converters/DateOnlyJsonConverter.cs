using System.Text.Json;
using System.Text.Json.Serialization;

namespace CringeLazer.Core.Converters;

/// <summary>
///  IT SHOULD BE MOVED AWAY FROM THE CORE PROJECT
/// </summary>
public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
