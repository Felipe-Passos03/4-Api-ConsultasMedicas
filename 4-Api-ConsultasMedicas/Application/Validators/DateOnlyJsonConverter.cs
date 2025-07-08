using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _4_Api_ConsultasMedicas.Application.Validators;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private readonly string _format = "dd/MM/yyyy";
    
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (DateOnly.TryParseExact(value, _format, null, DateTimeStyles.None, out var date))
        {
            return date;
        }
        throw new JsonException($"Data inválida. Use o formato {_format}");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}