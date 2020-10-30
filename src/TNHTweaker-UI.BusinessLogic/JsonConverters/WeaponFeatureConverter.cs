using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="WeaponFeature"/>.
    /// </summary>
    public class WeaponFeatureConverter : BaseEnumConverter<WeaponFeature>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override WeaponFeature ReadJson(JsonReader reader, Type objectType, WeaponFeature existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return WeaponFeature.None;

            return (WeaponFeature)Enum.Parse(typeof(WeaponFeature), arrayValues);
        }
    }
}