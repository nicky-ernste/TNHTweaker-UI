using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="ThrownDamageType"/>.
    /// </summary>
    public class ThrownDamageTypeConverter : BaseEnumConverter<ThrownDamageType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override ThrownDamageType ReadJson(JsonReader reader, Type objectType, ThrownDamageType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return ThrownDamageType.None;

            return (ThrownDamageType)Enum.Parse(typeof(ThrownDamageType), arrayValues);
        }
    }
}