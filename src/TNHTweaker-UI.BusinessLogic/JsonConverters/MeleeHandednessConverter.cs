using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="MeleeHandedness"/>.
    /// </summary>
    public class MeleeHandednessConverter : BaseEnumConverter<MeleeHandedness>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override MeleeHandedness ReadJson(JsonReader reader, Type objectType, MeleeHandedness existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return MeleeHandedness.None;

            return (MeleeHandedness)Enum.Parse(typeof(MeleeHandedness), arrayValues);
        }
    }
}