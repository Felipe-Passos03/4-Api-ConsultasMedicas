using System.Text.Json;
using System.Text.Json.Serialization;

namespace _4_Api_ConsultasMedicas.Application.Validators;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private const string _format = "HH:mm";
    
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timeString = reader.GetString();
        if (TimeOnly.TryParseExact(timeString, _format, out var time))
        {
            return time;
        }
        throw new JsonException($"Hora inválida. Use o formato {_format}");
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}