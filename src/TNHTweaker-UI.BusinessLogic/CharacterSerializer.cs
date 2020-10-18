using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.Models;
using TNHTweaker_UI.Models.Attributes;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.BusinessLogic
{
    /// <summary>
    /// Class that implements the <see cref="ICharacterSerializer"/> interface.
    /// </summary>
    public class CharacterSerializer : ICharacterSerializer
    {
        private readonly Dictionary<string, Type> _propertyToEnumDictionary = new Dictionary<string, Type>();

        public CharacterSerializer()
        {
            FillEnumDirectionary();
        }

        public CharacterInfo ReadCharacterFromString(string[] characterDefinition)
        {
            if (characterDefinition == null || !characterDefinition.Any())
                return null;

            //Filter out empty lines and lines that serve as comments.
            var filteredCharacterDefinition = characterDefinition.Where(line => !string.IsNullOrEmpty(line.Trim()) && !line.Trim().StartsWith("#")).ToArray();
            var characterInfo = new CharacterInfo();
            var characterBaseProperties = FindCustomProperties(typeof(CharacterInfo));

            for (var lineIndex = 0; lineIndex < filteredCharacterDefinition.Length; lineIndex++)
            {
                //Base character definition.
                var line = filteredCharacterDefinition[lineIndex];
                if (line.Contains("="))
                {
                    //Line is a statement
                    var lineSplit = line.Split('=');
                    FillInProperty(ref characterInfo, lineSplit[0], lineSplit[1], characterBaseProperties);
                }

                if ((line.Contains("Weapon_") && line.EndsWith("{")) || (line.Contains("Item_") && line.EndsWith("{")))
                {
                    //Stepping into weapon definitions.
                    var weaponDefinitionBaseProperties = FindCustomProperties(typeof(WeaponDefinition));
                    var property = line.Split('=')[0]?.TrimEnd('{');
                    var weaponDefinition = new WeaponDefinition();
                    var keepReading = true;
                    var indentCount = 0;

                    for (var innerLineIndex = lineIndex + 1; keepReading; innerLineIndex++)
                    {
                        var innerLine = filteredCharacterDefinition[innerLineIndex].Trim();
                        if (innerLine.Equals("{") || innerLine.EndsWith("["))
                            indentCount++;
                        if (innerLine.Equals("}") || innerLine.Equals("]"))
                        {
                            if (indentCount > 0)
                                indentCount--;
                            else
                            {
                                //Jump out of this section.
                                lineIndex = innerLineIndex - 1;
                                FillInProperty(ref characterInfo, property, weaponDefinition, characterBaseProperties);
                                keepReading = false;
                            }
                        }

                        if (indentCount == 2)
                        {
                            //Inside array of table definitions.
                            var objectTableDefinitionsBaseProperties = FindCustomProperties(typeof(ObjectTableDefinition));
                            var tableDefinition = new ObjectTableDefinition();
                            var keepReadingTableDef = true;
                            for (var tableDefIndex = innerLineIndex + 1; keepReadingTableDef; tableDefIndex++)
                            {
                                var tableDefLine = filteredCharacterDefinition[tableDefIndex].Trim();
                                if (tableDefLine.Equals("}"))
                                {
                                    weaponDefinition.TableDefs.Add(tableDefinition);
                                    innerLineIndex = tableDefIndex - 1; //Skip the lines we just read.
                                    keepReadingTableDef = false;
                                }

                                if (tableDefLine.Contains("="))
                                {
                                    //Line is a statement
                                    var lineSplit = tableDefLine.Split('=');
                                    FillInProperty(ref tableDefinition, lineSplit[0], lineSplit[1], objectTableDefinitionsBaseProperties);
                                }
                            }
                        }
                        if (innerLine.Contains("="))
                        {
                            //Line is a statement
                            var lineSplit = innerLine.Split('=');
                            FillInProperty(ref weaponDefinition, lineSplit[0], lineSplit[1],
                                weaponDefinitionBaseProperties);
                        }
                    }
                }
            }

            return characterInfo;
        }

        public string WriteCharacterToString(CharacterInfo character)
        {
            return string.Empty;
        }

        private void FillInProperty<T>(ref T instanceWithProperty, string property, object value, Dictionary<string, string> customProperties)
        {
            customProperties.TryGetValue(property, out var customPropertyName);
            if (string.IsNullOrEmpty(customPropertyName))
            {
                Console.WriteLine($"The property \"{property}\" was not found in the dictionary.");
                return; //Property not found in dictionary.
            }

            if (value is string stringValue)
            {
                _propertyToEnumDictionary.TryGetValue(property, out var enumType);
                if (enumType != null && !string.IsNullOrEmpty(stringValue))
                {
                    var enumValue = Enum.Parse(enumType, stringValue);
                    instanceWithProperty?.GetType().GetProperty(customPropertyName)
                        ?.SetValue(instanceWithProperty, enumValue);
                    return;
                }

                switch (Type.GetTypeCode(instanceWithProperty.GetType().GetProperty(customPropertyName)?.PropertyType))
                {
                    case TypeCode.Int32:
                        var intValue = int.Parse(string.IsNullOrEmpty(stringValue) ? "0" : stringValue);
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)
                            ?.SetValue(instanceWithProperty, intValue);
                        break;
                    case TypeCode.String:
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, value);
                        break;
                    case TypeCode.Boolean:
                        var boolValue = bool.Parse(stringValue);
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)
                            ?.SetValue(instanceWithProperty, boolValue);
                        break;
                    case TypeCode.Object:
                        if (property == "IDOverride")
                            instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, stringValue.Split(','));
                        break;
                }
            }
            else
                instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, value);
        }

        private void SetProperty<T>(ref T instance, string property, object value)
        {
            instance.GetType().GetProperty(property)?.SetValue(instance, value);
        }

        private Dictionary<string, string> FindCustomProperties(Type type)
        {
            var properties = type.GetProperties();
            var propertiesDictionary = new Dictionary<string, string>();
            foreach (var property in properties)
            {
                var customPropertyName = property.GetCustomAttribute<PropertyNameAttribute>()?.PropertyName;
                propertiesDictionary.Add(string.IsNullOrEmpty(customPropertyName) ? property.Name : customPropertyName, property.Name);
            }

            return propertiesDictionary;
        }

        private void FillEnumDirectionary()
        {
            _propertyToEnumDictionary.Add("Category", typeof(ItemCategory));
            _propertyToEnumDictionary.Add("Eras", typeof(EraType));
            _propertyToEnumDictionary.Add("Sets", typeof(SetType));
            _propertyToEnumDictionary.Add("Sizes", typeof(WeaponSize));
            _propertyToEnumDictionary.Add("Actions", typeof(WeaponActionType));
            _propertyToEnumDictionary.Add("Modes", typeof(WeaponMode));
            _propertyToEnumDictionary.Add("ExcludeModes", typeof(WeaponMode));
            _propertyToEnumDictionary.Add("Feedoptions", typeof(FeedOption));
            _propertyToEnumDictionary.Add("MountsAvailable", typeof(MountType));
            _propertyToEnumDictionary.Add("RoundPowers", typeof(RoundPower));
            _propertyToEnumDictionary.Add("Features", typeof(WeaponFeature));
            _propertyToEnumDictionary.Add("MeleeStyles", typeof(MeleeStyle));
            _propertyToEnumDictionary.Add("MeleeHandedness", typeof(MeleeHandedness));
            _propertyToEnumDictionary.Add("MountTypes", typeof(MountType));
            _propertyToEnumDictionary.Add("PowerupTypes", typeof(PowerupType));
            _propertyToEnumDictionary.Add("ThrownTypes", typeof(ThrownType));
            _propertyToEnumDictionary.Add("ThrownDamageTypes", typeof(ThrownDamageType));
        }
    }
}