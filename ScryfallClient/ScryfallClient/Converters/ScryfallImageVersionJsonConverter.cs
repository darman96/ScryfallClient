using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallClient.Enums;

namespace ScryfallClient.Converters
{
    public class ScryfallImageVersionJsonConverter : JsonConverter<ImageVersion>
    {
        public override ImageVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = reader.GetString() ?? throw new JsonException("Value cannot be null.");

            return enumString switch
            {
                "small" => ImageVersion.Small,
                "normal" => ImageVersion.Normal,
                "large" => ImageVersion.Large,
                "png" => ImageVersion.Png,
                "art_crop" => ImageVersion.ArtCrop,
                "border_crop" => ImageVersion.BorderCrop,
                _ => throw new JsonException($"Unknown ImageVersion value: {enumString}")
            };
        }

        public override void Write(Utf8JsonWriter writer, ImageVersion value, JsonSerializerOptions options)
        {
            var stringValue = value switch
            {
                ImageVersion.Small => "small",
                ImageVersion.Normal => "normal",
                ImageVersion.Large => "large",
                ImageVersion.Png => "png",
                ImageVersion.ArtCrop => "art_crop",
                ImageVersion.BorderCrop => "border_crop",
                _ => throw new JsonException($"Unsupported ImageVersion: {value}")
            };

            writer.WriteStringValue(stringValue);
        }

    }
}