using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="ThrownType"/>.
    /// </summary>
    public class ThrownTypeConverter : BaseEnumConverter<ThrownType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override ThrownType ReadJson(JsonReader reader, Type objectType, ThrownType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return ThrownType.None;

            return (ThrownType)Enum.Parse(typeof(ThrownType), arrayValues);
        }
    }
}