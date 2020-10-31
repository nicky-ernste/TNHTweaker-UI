using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic.JsonConverters
{
    public abstract class BaseEnumConverter<T> : JsonConverter<T>
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            var stringValues = value.ToString().Split(',').ToList();
            writer.WriteStartArray();

            //If the only value in an enum type is "None" or "0" then we write an empty array.
            if (stringValues.Count >= 1 && !stringValues[0].Equals("0") && !stringValues[0].Equals(nameof(EraType.None)))
                stringValues.ForEach(sv => writer.WriteValue(sv.Trim()));

            writer.WriteEndArray();
        }

        /// <summary>
        /// Attempts to get the values of a JSON array as a comma separated string.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> instance that is reading a JSON file.</param>
        /// <returns>A comma separated list of the array values. Or <c>null</c> if there is no array to read, or it's empty.</returns>
        protected string GetArrayValuesAsCommaSeparatedString(JsonReader reader)
        {
            if (reader.TokenType != JsonToken.StartArray)
                return null;

            var array = JArray.Load(reader);
            var values = array.ToObject<IList<string>>();
            if (values == null || !values.Any())
                return null;

            return string.Join(",", values);
        }
    }
}