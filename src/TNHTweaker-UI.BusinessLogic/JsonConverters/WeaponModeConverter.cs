using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="WeaponMode"/>.
    /// </summary>
    public class WeaponModeConverter : BaseEnumConverter<WeaponMode>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override WeaponMode ReadJson(JsonReader reader, Type objectType, WeaponMode existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return WeaponMode.None;

            return (WeaponMode)Enum.Parse(typeof(WeaponMode), arrayValues);
        }
    }
}