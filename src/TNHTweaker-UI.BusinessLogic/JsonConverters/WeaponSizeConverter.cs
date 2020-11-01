using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="WeaponSize"/>.
    /// </summary>
    public class WeaponSizeConverter : BaseEnumConverter<WeaponSize>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override WeaponSize ReadJson(JsonReader reader, Type objectType, WeaponSize existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return WeaponSize.None;

            return (WeaponSize)Enum.Parse(typeof(WeaponSize), arrayValues);
        }
    }
}