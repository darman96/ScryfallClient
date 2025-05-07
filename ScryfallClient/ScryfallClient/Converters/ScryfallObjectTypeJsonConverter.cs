using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallClient.Enums;

namespace ScryfallClient.Converters
{
    public class ScryfallObjectTypeJsonConverter : JsonConverter<ScryfallObjectType>
    {
        public override ScryfallObjectType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = reader.GetString() ?? throw new InvalidOperationException();

            return enumString switch
            {
                "set" => ScryfallObjectType.Set,
                "card" => ScryfallObjectType.Card,
                "card_face" => ScryfallObjectType.CardFace,
                "related_card" => ScryfallObjectType.RelatedCard,
                "ruling" => ScryfallObjectType.Ruling,
                "card_symbol" => ScryfallObjectType.CardSymbol,
                "catalog" => ScryfallObjectType.Catalog,
                "list" => ScryfallObjectType.List,
                "error" => ScryfallObjectType.Error,
                _ => throw new JsonException($"Unknown ScryfallObjectType value: {enumString}")
            };
        }

        public override void Write(Utf8JsonWriter writer, ScryfallObjectType value, JsonSerializerOptions options)
        {
            var stringValue = value switch
            {
                ScryfallObjectType.Set => "set",
                ScryfallObjectType.Card => "card",
                ScryfallObjectType.CardFace => "card_face",
                ScryfallObjectType.RelatedCard => "related_card",
                ScryfallObjectType.Ruling => "ruling",
                ScryfallObjectType.CardSymbol => "card_symbol",
                ScryfallObjectType.Catalog => "catalog",
                ScryfallObjectType.List => "list",
                ScryfallObjectType.Error => "error",
                _ => throw new JsonException($"Unsupported ScryfallObjectType: {value}")
            };

            writer.WriteStringValue(stringValue);
        }
    }
}