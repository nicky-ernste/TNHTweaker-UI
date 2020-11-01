using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="MountType"/>.
    /// </summary>
    public class MountTypeConverter : BaseEnumConverter<MountType>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override MountType ReadJson(JsonReader reader, Type objectType, MountType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return MountType.None;

            return (MountType)Enum.Parse(typeof(MountType), arrayValues);
        }
    }
}