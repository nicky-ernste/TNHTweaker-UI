using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="SetType"/>.
    /// </summary>
    public class SetTypeConverter : BaseEnumConverter<SetType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override SetType ReadJson(JsonReader reader, Type objectType, SetType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return SetType.None;

            return (SetType)Enum.Parse(typeof(SetType), arrayValues);
        }
    }
}