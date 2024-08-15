using System.Text.Json;
using System.Text.Json.Serialization;
using WebApi.ActivitySheets;

namespace WebApi.Framework.Json;

internal sealed class ActivitySheetNameConverter : JsonConverter<ActivitySheetName>
{
    public override bool HandleNull => true;

    public override ActivitySheetName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Unable to deserialize type '{nameof(ActivitySheetName)}': expected a string");
        }

        var value = reader.GetString();

        try
        {
            return ActivitySheetName.Create(value);
        }
        catch (ArgumentException e)
        {
            throw new JsonException($"Unable to deserialize type '{nameof(ActivitySheetName)}'", e);
        }

        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ActivitySheetName value, JsonSerializerOptions options) => throw new NotImplementedException();
}
