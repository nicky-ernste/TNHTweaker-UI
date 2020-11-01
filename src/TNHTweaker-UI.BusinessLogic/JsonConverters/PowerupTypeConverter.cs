using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="PowerupType"/>.
    /// </summary>
    public class PowerupTypeConverter : BaseEnumConverter<PowerupType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override PowerupType ReadJson(JsonReader reader, Type objectType, PowerupType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return PowerupType.None;

            return (PowerupType)Enum.Parse(typeof(PowerupType), arrayValues);
        }
    }
}