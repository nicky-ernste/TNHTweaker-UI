using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an integer value into a enum value of type <see cref="CharacterGroup"/> and back.
    /// </summary>
    public class CharacterGroupConverter : BaseEnumConverter<CharacterGroup>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override CharacterGroup ReadJson(JsonReader reader, Type objectType, CharacterGroup existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (hasExistingValue)
                return existingValue;

            if (!int.TryParse(reader.ReadAsString(), out var intValue))
                return CharacterGroup.DaringDefaults;

            return (CharacterGroup)intValue;
        }

        ///<inheritdoc cref="JsonConverter{T}"/>
        public override void WriteJson(JsonWriter writer, CharacterGroup value, JsonSerializer serializer) => writer.WriteValue((int)value);
    }
}