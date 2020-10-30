using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.BusinessLogic.JsonConverters;
using TNHTweaker_UI.Models;

namespace TNHTweaker_UI.BusinessLogic
{
    /// <summary>
    /// Implementation of the <see cref="ICharacterSerializer"/> using the new JSON custom character format.
    /// </summary>
    public class CharacterSerializer : ICharacterSerializer
    {
        public CharacterInformation ReadCharacterFromString(string characterDefinition) =>
            JsonConvert.DeserializeObject<CharacterInformation>(characterDefinition, SetupJsonSerializer());

        public string WriteCharacterToString(CharacterInformation character) =>
            JsonConvert.SerializeObject(character, Formatting.Indented, SetupJsonSerializer());

        /// <summary>
        /// Sets up the default serializer settings that are used when converting to and from JSON.
        /// </summary>
        /// <returns>An instance of <see cref="JsonSerializerSettings"/> that has registered all custom converters.</returns>
        private static JsonSerializerSettings SetupJsonSerializer() =>
            new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new EraTypeConverter(),
                    new FeedOptionConverter(),
                    new MeleeHandednessConverter(),
                    new MeleeStyleConverter(),
                    new MountTypeConverter(),
                    new PowerupTypeConverter(),
                    new RoundPowerConverter(),
                    new SetTypeConverter(),
                    new ThrownDamageTypeConverter(),
                    new ThrownTypeConverter(),
                    new WeaponActionTypeConverter(),
                    new WeaponFeatureConverter(),
                    new WeaponModeConverter(),
                    new WeaponSizeConverter(),
                    new StringEnumConverter()
                }
            };
    }
}