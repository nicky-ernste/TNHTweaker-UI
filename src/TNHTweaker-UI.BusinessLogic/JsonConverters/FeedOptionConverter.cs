using System;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    /// <summary>
    /// Custom JSON converter that converts an array of string values into a flagged enum value of type <see cref="FeedOption"/>.
    /// </summary>
    public class FeedOptionConverter : BaseEnumConverter<FeedOption>
    {
        ///<inheritdoc cref="JsonConverter{T}"/>
        public override FeedOption ReadJson(JsonReader reader, Type objectType, FeedOption existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var arrayValues = GetArrayValuesAsCommaSeparatedString(reader);
            if (string.IsNullOrEmpty(arrayValues))
                return FeedOption.None;

            return (FeedOption)Enum.Parse(typeof(FeedOption), arrayValues);
        }
    }
}