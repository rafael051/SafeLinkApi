using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SafeLinkApi.Converters
{
    /// <summary>
    /// Conversor de datas para aceitar e formatar valores no padrão pt-BR (ex: 01/01/2025 15:30:00)
    /// </summary>
    public class DateTimePtBrConverter : JsonConverter<DateTime>
    {
        private readonly string[] _formats = new[]
        {
            "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy"
        };

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();

            if (DateTime.TryParseExact(str, _formats, CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var date))
                return date;

            throw new JsonException($"Data inválida. Esperado: dd/MM/yyyy ou dd/MM/yyyy HH:mm:ss. Recebido: {str}");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")));
        }
    }
}
