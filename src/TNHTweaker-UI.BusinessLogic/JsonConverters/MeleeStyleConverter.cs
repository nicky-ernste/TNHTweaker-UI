using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="MeleeStyle"/>.
    /// </summary>
    public class MeleeStyleConverter : BaseEnumConverter<MeleeStyle>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override MeleeStyle ReadJson(JsonReader reader, Type objectType, MeleeStyle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return MeleeStyle.None;

            return (MeleeStyle)Enum.Parse(typeof(MeleeStyle), arrayValues);
        }
    }
}