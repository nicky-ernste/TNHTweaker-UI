using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="WeaponActionType"/>.
    /// </summary>
    public class WeaponActionTypeConverter : BaseEnumConverter<WeaponActionType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override WeaponActionType ReadJson(JsonReader reader, Type objectType, WeaponActionType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return WeaponActionType.None;

            return (WeaponActionType)Enum.Parse(typeof(WeaponActionType), arrayValues);
        }
    }
}