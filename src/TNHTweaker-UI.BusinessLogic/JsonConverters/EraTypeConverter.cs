using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="EraType"/>.
    /// </summary>
    public class EraTypeConverter : BaseEnumConverter<EraType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override EraType ReadJson(JsonReader reader, Type objectType, EraType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return EraType.None;

            return (EraType)Enum.Parse(typeof(EraType), arrayValues);
        }
    }
}