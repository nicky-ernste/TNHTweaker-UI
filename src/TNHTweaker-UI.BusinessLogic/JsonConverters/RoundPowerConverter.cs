using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="RoundPower"/>.
    /// </summary>
    public class RoundPowerConverter : BaseEnumConverter<RoundPower>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override RoundPower ReadJson(JsonReader reader, Type objectType, RoundPower existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return RoundPower.None;

            return (RoundPower)Enum.Parse(typeof(RoundPower), arrayValues);
        }
    }
}