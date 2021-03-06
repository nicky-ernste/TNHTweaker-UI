﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.Models.Attributes;
using TNHTweaker_UI.Models.Enums;
using TNHTweaker_UI.Models.OldFormat;

namespace TNHTweaker_UI.BusinessLogic
{
    /// <summary>
    /// Class that implements the <see cref="ICharacterSerializer"/> interface.
    /// Using the old proprietary custom character format.
    /// </summary>
    public class CharacterSerializerOld : ICharacterSerializerOld
    {
        private readonly Dictionary<string, Type> _propertyToEnumDictionary = new Dictionary<string, Type>();

        public CharacterSerializerOld()
        {
            FillEnumDictionary();
        }

        public CharacterInfo ReadCharacterFromStringOldFormat(string[] characterDefinition)
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
                FillInPropertyIfStatement(line, ref characterInfo, characterBaseProperties);

                if (line.Contains("Weapon_") && line.EndsWith("{") || line.Contains("Item_") && line.EndsWith("{"))
                {
                    //Stepping into weapon definitions.
                    var weaponDefinitionBaseProperties = FindCustomProperties(typeof(WeaponDefinition));
                    var property = line.Split('=')[0]?.TrimEnd('{');
                    var weaponDefinition = new WeaponDefinition();
                    var keepReadingWeaponDefinition = true;
                    var weaponDefinitionIndentCount = 0;

                    for (var weaponDefinitionIndex = lineIndex + 1; keepReadingWeaponDefinition; weaponDefinitionIndex++)
                    {
                        var weaponDefinitionLine = filteredCharacterDefinition[weaponDefinitionIndex].Trim();
                        if (weaponDefinitionLine.Equals("{") || weaponDefinitionLine.EndsWith("["))
                            weaponDefinitionIndentCount++;
                        if (weaponDefinitionLine.Equals("}") || weaponDefinitionLine.Equals("]"))
                        {
                            if (weaponDefinitionIndentCount > 0)
                                weaponDefinitionIndentCount--;
                            else
                            {
                                //Jump out of this section.
                                lineIndex = weaponDefinitionIndex - 1;
                                FillInProperty(ref characterInfo, property, weaponDefinition, characterBaseProperties);
                                keepReadingWeaponDefinition = false;
                            }
                        }

                        if (weaponDefinitionIndentCount == 2)
                        {
                            //Inside array of table definitions.
                            var objectTableDefinitionsBaseProperties = FindCustomProperties(typeof(ObjectTableDefinition));
                            var tableDefinition = new ObjectTableDefinition();
                            var keepReadingTableDef = true;
                            for (var tableDefIndex = weaponDefinitionIndex + 1; keepReadingTableDef; tableDefIndex++)
                            {
                                var tableDefLine = filteredCharacterDefinition[tableDefIndex].Trim();
                                if (tableDefLine.Equals("}"))
                                {
                                    weaponDefinition.TableDefs.Add(tableDefinition);
                                    weaponDefinitionIndex = tableDefIndex - 1; //Skip the lines we just read.
                                    keepReadingTableDef = false;
                                }

                                FillInPropertyIfStatement(tableDefLine, ref tableDefinition, objectTableDefinitionsBaseProperties);
                            }
                        }

                        FillInPropertyIfStatement(weaponDefinitionLine, ref weaponDefinition, weaponDefinitionBaseProperties);
                    }
                }

                if (line.Equals("EquipmentPool{"))
                {
                    //Stepping into equipment pools.
                    var equipmentPool = new EquipmentPoolDefinition();
                    var property = line.Split('=')[0]?.TrimEnd('{');
                    var keepReading = true;
                    var indentCount = 0;

                    for (var poolIndex = lineIndex + 1; keepReading; poolIndex++)
                    {
                        var poolLine = filteredCharacterDefinition[poolIndex].Trim();
                        if (poolLine.Equals("{") || poolLine.EndsWith("["))
                            indentCount++;
                        if (poolLine.Equals("}") || poolLine.Equals("]"))
                        {
                            if (indentCount > 0)
                                indentCount--;
                            else
                            {
                                //Jump out of this section.
                                lineIndex = poolIndex - 1;
                                keepReading = false;
                            }
                        }

                        if (indentCount == 2)
                        {
                            //Inside array of pool entries.
                            var poolEntryBaseProperties = FindCustomProperties(typeof(PoolEntry));
                            var poolEntry = new PoolEntry();
                            var keepReadingPoolEntry = true;
                            var entryIndentCount = 0;
                            for (var entryIndex = poolIndex + 1; keepReadingPoolEntry; entryIndex++)
                            {
                                var entryLine = filteredCharacterDefinition[entryIndex].Trim();
                                if (entryLine.EndsWith("{") || entryLine.EndsWith("["))
                                    entryIndentCount++;
                                if (entryLine.Equals("}") || entryLine.Equals("]"))
                                {
                                    if (entryIndentCount > 0)
                                        entryIndentCount--;
                                    else
                                    {
                                        //Jump out of this section.
                                        poolIndex = entryIndex - 1;
                                        equipmentPool.Entries.Add(poolEntry);
                                        keepReadingPoolEntry = false;
                                    }
                                }

                                if (entryIndentCount == 1)
                                {
                                    //Stepping inside of table definition.
                                    var objectTableDefinitionsBaseProperties = FindCustomProperties(typeof(ObjectTableDefinition));
                                    var tableDefinition = new ObjectTableDefinition();
                                    var keepReadingTableDef = true;
                                    for (var tableDefIndex = entryIndex + 1; keepReadingTableDef; tableDefIndex++)
                                    {
                                        var tableDefLine = filteredCharacterDefinition[tableDefIndex].Trim();
                                        if (tableDefLine.Equals("}"))
                                        {
                                            poolEntry.TableDef = tableDefinition;
                                            entryIndex = tableDefIndex - 1; //Skip the lines we just read.
                                            keepReadingTableDef = false;
                                        }

                                        FillInPropertyIfStatement(tableDefLine, ref tableDefinition, objectTableDefinitionsBaseProperties);
                                    }
                                }

                                FillInPropertyIfStatement(entryLine, ref poolEntry, poolEntryBaseProperties);
                            }
                        }
                    }

                    FillInProperty(ref characterInfo, property, equipmentPool, characterBaseProperties);
                }

                if (line.Equals("Progressions["))
                {
                    //Stepping into progressions.
                    var progressionDefinition = new ProgressionDefinition();
                    var keepReading = true;
                    var firstLevel = true; //TODO Ugly hack that should be changed,
                    var indentCount = 0;

                    for (var progressionIndex = lineIndex + 1; keepReading; progressionIndex++)
                    {
                        var progressionLine = filteredCharacterDefinition[progressionIndex].Trim();
                        if (progressionLine.Equals("{") || progressionLine.EndsWith("["))
                            indentCount++;
                        if (progressionLine.Equals("}") || progressionLine.Equals("]"))
                        {
                            if (indentCount > 0)
                                indentCount--;
                            else
                            {
                                //Jump out of this section.
                                lineIndex = progressionIndex - 1;
                                characterInfo.Progressions.Add(progressionDefinition);
                                keepReading = false;
                            }
                        }

                        if (indentCount == 2)
                        {
                            //Inside array of levels.
                            var levelEntryBaseProperties = FindCustomProperties(typeof(LevelEntry));
                            var levelEntry = new LevelEntry();
                            var keepReadingLevelEntry = true;
                            var entryIndentCount = 0;
                            for (var entryIndex = firstLevel ? progressionIndex + 2 : progressionIndex + 1; keepReadingLevelEntry; entryIndex++)
                            {
                                var entryLine = filteredCharacterDefinition[entryIndex].Trim();
                                if (entryLine.EndsWith("{") || entryLine.EndsWith("["))
                                    entryIndentCount++;
                                if (entryLine.Equals("}") || entryLine.Equals("]"))
                                {
                                    if (entryIndentCount > 0)
                                        entryIndentCount--;
                                    else
                                    {
                                        //Jump out of this section.
                                        progressionIndex = entryIndex - 1;
                                        progressionDefinition.Levels.Add(levelEntry);
                                        keepReadingLevelEntry = false;
                                        firstLevel = false;
                                    }
                                }

                                if (entryIndentCount == 1 && (entryLine.Equals("TakeChallenge{") || entryLine.Equals("SupplyChallenge{")))
                                {
                                    var challengeBaseProperties = FindCustomProperties(typeof(TakeSupplyChallenge));
                                    var challenge = new TakeSupplyChallenge();
                                    var challengeProperty = entryLine.TrimEnd('{');
                                    var keepReadingChallenge = true;
                                    for (var challengeIndex = entryIndex + 1; keepReadingChallenge; challengeIndex++)
                                    {
                                        var challengeLine = filteredCharacterDefinition[challengeIndex].Trim();
                                        if (challengeLine.Equals("}"))
                                        {
                                            //Jump out of this section.
                                            entryIndex = challengeIndex - 1;
                                            FillInProperty(ref levelEntry, challengeProperty, challenge, levelEntryBaseProperties);
                                            keepReadingChallenge = false;
                                        }

                                        FillInPropertyIfStatement(challengeLine, ref challenge, challengeBaseProperties);
                                    }
                                }

                                if (entryIndentCount == 1 && (entryLine.Equals("HoldChallenge{")))
                                {
                                    var holdChallenge = new HoldChallenge();
                                    var challengeProperty = entryLine.TrimEnd('{');
                                    var keepReadingHoldChallenge = true;
                                    var holdChallengeIndentCount = 0;
                                    for (var holdChallengeIndex = entryIndex + 1; keepReadingHoldChallenge; holdChallengeIndex++)
                                    {
                                        var holdChallengeLine = filteredCharacterDefinition[holdChallengeIndex].Trim();
                                        if (holdChallengeLine.EndsWith("{") || holdChallengeLine.EndsWith("["))
                                            holdChallengeIndentCount++;
                                        if (holdChallengeLine.Equals("}") || holdChallengeLine.Equals("]"))
                                        {
                                            if (holdChallengeIndentCount > 0)
                                                holdChallengeIndentCount--;
                                            else
                                            {
                                                //Jump out of this section.
                                                entryIndex = holdChallengeIndex - 1;
                                                FillInProperty(ref levelEntry, challengeProperty, holdChallenge, levelEntryBaseProperties);
                                                keepReadingHoldChallenge = false;
                                            }
                                        }
                                        if (holdChallengeIndentCount == 2)
                                        {
                                            var phaseBaseProperties = FindCustomProperties(typeof(PhaseDefinition));
                                            var phaseDefinition = new PhaseDefinition();
                                            var keepReadingPhase = true;
                                            for (var phaseIndex = holdChallengeIndex + 1; keepReadingPhase; phaseIndex++)
                                            {
                                                var phaseLine = filteredCharacterDefinition[phaseIndex].Trim();
                                                if (phaseLine.Equals("}"))
                                                {
                                                    //Jump out of this section.
                                                    holdChallengeIndex = phaseIndex - 1;
                                                    holdChallenge.Phases.Add(phaseDefinition);
                                                    keepReadingPhase = false;
                                                }

                                                FillInPropertyIfStatement(phaseLine, ref phaseDefinition, phaseBaseProperties);
                                            }
                                        }
                                    }
                                }

                                if (entryIndentCount == 1 && (entryLine.Equals("PatrolChallenge{")))
                                {
                                    var patrolChallenge = new PatrolChallenge();
                                    var challengeProperty = entryLine.TrimEnd('{');
                                    var keepReadingPatrolChallenge = true;
                                    var patrolChallengeIndentCount = 0;
                                    for (var patrolChallengeIndex = entryIndex + 1; keepReadingPatrolChallenge; patrolChallengeIndex++)
                                    {
                                        var patrolChallengeLine = filteredCharacterDefinition[patrolChallengeIndex].Trim();
                                        if (patrolChallengeLine.EndsWith("{") || patrolChallengeLine.EndsWith("["))
                                            patrolChallengeIndentCount++;
                                        if (patrolChallengeLine.Equals("}") || patrolChallengeLine.Equals("]"))
                                        {
                                            if (patrolChallengeIndentCount > 0)
                                                patrolChallengeIndentCount--;
                                            else
                                            {
                                                //Jump out of this section.
                                                entryIndex = patrolChallengeIndex - 1;
                                                FillInProperty(ref levelEntry, challengeProperty, patrolChallenge, levelEntryBaseProperties);
                                                keepReadingPatrolChallenge = false;
                                            }
                                        }
                                        if (patrolChallengeIndentCount == 2)
                                        {
                                            var patrolBaseProperties = FindCustomProperties(typeof(PatrolDefinition));
                                            var patrolDefinition = new PatrolDefinition();
                                            var keepReadingPatrol = true;
                                            for (var patrolIndex = patrolChallengeIndex + 1; keepReadingPatrol; patrolIndex++)
                                            {
                                                var patrolLine = filteredCharacterDefinition[patrolIndex].Trim();
                                                if (patrolLine.Equals("}"))
                                                {
                                                    //Jump out of this section.
                                                    patrolChallengeIndex = patrolIndex - 1;
                                                    patrolChallenge.Patrols.Add(patrolDefinition);
                                                    keepReadingPatrol = false;
                                                }

                                                FillInPropertyIfStatement(patrolLine, ref patrolDefinition, patrolBaseProperties);
                                            }
                                        }
                                    }
                                }

                                if (entryIndentCount == 1 && (entryLine.Equals("TrapsChallenge{")))
                                {
                                    var trapsChallenge = new TrapsChallenge();
                                    var challengeProperty = entryLine.TrimEnd('{');
                                    var keepReadingTrapsChallenge = true;
                                    var trapsChallengeIndentCount = 0;
                                    for (var trapsChallengeIndex = entryIndex + 1; keepReadingTrapsChallenge; trapsChallengeIndex++)
                                    {
                                        var trapsChallengeLine = filteredCharacterDefinition[trapsChallengeIndex].Trim();
                                        if (trapsChallengeLine.EndsWith("{") || trapsChallengeLine.EndsWith("["))
                                            trapsChallengeIndentCount++;
                                        if (trapsChallengeLine.Equals("}") || trapsChallengeLine.Equals("]"))
                                        {
                                            if (trapsChallengeIndentCount > 0)
                                                trapsChallengeIndentCount--;
                                            else
                                            {
                                                //Jump out of this section.
                                                entryIndex = trapsChallengeIndex - 1;
                                                FillInProperty(ref levelEntry, challengeProperty, trapsChallenge, levelEntryBaseProperties);
                                                keepReadingTrapsChallenge = false;
                                            }
                                        }
                                        if (trapsChallengeIndentCount == 2)
                                        {
                                            var trapBaseProperties = FindCustomProperties(typeof(TrapDefinition));
                                            var trapDefinition = new TrapDefinition();
                                            var keepReadingTrap = true;
                                            for (var trapIndex = trapsChallengeIndex + 1; keepReadingTrap; trapIndex++)
                                            {
                                                var trapLine = filteredCharacterDefinition[trapIndex].Trim();
                                                if (trapLine.Equals("}"))
                                                {
                                                    //Jump out of this section.
                                                    trapsChallengeIndex = trapIndex - 1;
                                                    trapsChallenge.Traps.Add(trapDefinition);
                                                    keepReadingTrap = false;
                                                }

                                                FillInPropertyIfStatement(trapLine, ref trapDefinition, trapBaseProperties);
                                            }
                                        }
                                    }
                                }

                                FillInPropertyIfStatement(entryLine, ref levelEntry, levelEntryBaseProperties);
                            }
                        }
                    }
                }
            }

            return characterInfo;
        }

        public string WriteCharacterToStringOldFormat(CharacterInfo character)
        {
            if (character == null)
                return string.Empty;
            var sb = new StringBuilder();
            var charInfoBaseProperties = FindCustomPropertiesReverse(typeof(CharacterInfo));
            WriteObjectToText(ref sb, character, charInfoBaseProperties);

            return sb.ToString();
        }

        /// <summary>
        /// Attempts to fill a property on the given <paramref name="instanceWithProperty"/> using reflection.
        /// </summary>
        /// <typeparam name="T">The type of the object with the given <paramref name="property"/> that needs the given <paramref name="value"/>.</typeparam>
        /// <param name="instanceWithProperty">The instance of <typeparamref name="T"/> that needs to have the given <paramref name="property"/> filled with the given <paramref name="value"/>.</param>
        /// <param name="property">The property on <paramref name="instanceWithProperty"/> that needs to get the given <paramref name="value"/>.</param>
        /// <param name="value">The value that will be inserted on the given <paramref name="property"/> on the specified <paramref name="instanceWithProperty"/>.</param>
        /// <param name="customProperties">A <see cref="Dictionary{TKey,TValue}"/> that holds any custom property names for <paramref name="instanceWithProperty"/>.</param>
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
                if (property.Equals("Type") && instanceWithProperty is TrapDefinition)
                    enumType = typeof(TrapType); //TODO ugly override for a property with the same name but different type.
                if (enumType != null)
                {
                    if (string.IsNullOrEmpty(stringValue))
                        stringValue = "1"; //Since there are no zero values we set it to 1 so it well serialize to the "None" enum value.
                    var enumValue = Enum.Parse(enumType, stringValue);
                    instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, enumValue);
                    return;
                }

                // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault Will add more cases if needed.
                switch (Type.GetTypeCode(instanceWithProperty.GetType().GetProperty(customPropertyName)?.PropertyType))
                {
                    case TypeCode.Int32:
                        var intValue = int.Parse(string.IsNullOrEmpty(stringValue) ? "0" : stringValue);
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, intValue);
                        break;
                    case TypeCode.Single:
                        stringValue = stringValue.Replace('.', ',');
                        var decimalValue = float.Parse(string.IsNullOrEmpty(stringValue) ? "0.0" : stringValue);
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, decimalValue);
                        break;
                    case TypeCode.String:
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, value);
                        break;
                    case TypeCode.Boolean:
                        var boolValue = bool.Parse(stringValue);
                        instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, boolValue);
                        break;
                    case TypeCode.Object:
                        if (property == "IDOverride")
                            instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, stringValue.Split(','));
                        break;
                    default:
                        Console.WriteLine($"WARNING Could not fill in property of type: {instanceWithProperty.GetType().GetProperty(customPropertyName)?.PropertyType} For property: {property}");
                        break;
                }
            }
            else
                instanceWithProperty?.GetType().GetProperty(customPropertyName)?.SetValue(instanceWithProperty, value);
        }

        /// <summary>
        /// Fills in the property on <paramref name="objectToFill"/> that is contained in <paramref name="textLine"/>, if <paramref name="textLine"/> represents a statement.
        /// </summary>
        /// <typeparam name="T">The type of object the fill a property on.</typeparam>
        /// <param name="textLine">The line of text to examine.</param>
        /// <param name="objectToFill">The instance of <typeparamref name="T"/> to fill a property on.</param>
        /// <param name="customProperties">A <see cref="Dictionary{TKey,TValue}"/> that holds any custom property names for <paramref name="objectToFill"/>.</param>
        void FillInPropertyIfStatement<T>(string textLine, ref T objectToFill, Dictionary<string, string> customProperties)
        {
            if (!textLine.Contains("="))
                return;

            //Line is a statement
            var lineSplit = textLine.Split('=');
            FillInProperty(ref objectToFill, lineSplit[0], lineSplit[1], customProperties);
        }

        /// <summary>
        /// Find any properties of the given type <paramref name="objectType"/> that are annotated with <see cref="PropertyNameAttribute"/>. and put those in a mapping dictionary.
        /// If a property of the given type <paramref name="objectType"/> does not have a <see cref="PropertyNameAttribute"/> its original name will be used instead.
        /// This method does NOT recurse into object type properties!
        /// </summary>
        /// <param name="objectType">The type to find the custom property names for if any.</param>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> that holds the custom name of any, and the actually used property name in the model.</returns>
        private Dictionary<string, string> FindCustomProperties(Type objectType)
        {
            var properties = objectType.GetProperties();
            var propertiesDictionary = new Dictionary<string, string>();
            foreach (var property in properties)
            {
                var customPropertyName = property.GetCustomAttribute<PropertyNameAttribute>()?.PropertyName;
                propertiesDictionary.Add(string.IsNullOrEmpty(customPropertyName) ? property.Name : customPropertyName, property.Name);
            }

            return propertiesDictionary;
        }

        /// <summary>
        /// Find any properties of the given type <paramref name="objectType"/> that are annotated with <see cref="PropertyNameAttribute"/>. and put those in a mapping dictionary.
        /// The mappings will be in reverse of what <see cref="FindCustomProperties"/> returns.
        /// If a property of the given type <paramref name="objectType"/> does not have a <see cref="PropertyNameAttribute"/> its original name will be used instead.
        /// This method does NOT recurse into object type properties!
        /// </summary>
        /// <param name="objectType">The type to find the custom property names for if any.</param>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> that holds the custom name of any, and the actually used property name in the model.</returns>
        private Dictionary<string, string> FindCustomPropertiesReverse(Type objectType)
        {
            var customProps = FindCustomProperties(objectType);
            return customProps.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        /// <summary>
        /// Writes properties of the given <see cref="objectToWrite"/> to texts in the format of the custom character file.
        /// This is a recursive method that maps out all sub objects in the given <paramref name="objectToWrite"/>.
        /// </summary>
        /// <param name="sb">A reference to a <see cref="StringBuilder"/> that is used to build the string for the custom character.</param>
        /// <param name="objectToWrite">The instance of <paramref name="objectToWrite"/> that needs to be written to text format..</param>
        /// <param name="customProperties">A <see cref="Dictionary{TKey,TValue}"/> that holds any custom property names for <paramref name="objectToWrite"/>.</param>
        private void WriteObjectToText(ref StringBuilder sb, object objectToWrite, Dictionary<string, string> customProperties)
        {
            var properties = objectToWrite.GetType().GetProperties();
            foreach (var property in properties)
            {
                customProperties.TryGetValue(property.Name, out var customPropertyName);
                if (string.IsNullOrEmpty(customPropertyName))
                {
                    Console.WriteLine($"The property \"{property}\" was not found in the dictionary.");
                    return; //Property not found in dictionary.
                }

                // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault Will add more cases if needed.
                switch (Type.GetTypeCode(property.PropertyType))
                {
                    case TypeCode.Int32:
                        var intValue = (int)property.GetValue(objectToWrite);

                        if (customPropertyName == "@AdditionalSupplyPoints" && intValue == 0) //BUG VERY SENSITIVE FOR FILE FORMAT CHANGES!
                            break; //Skip empty additional supply points.
                        if (property.PropertyType.IsEnum)
                        {
                            if (property.PropertyType == typeof(CharacterGroup))
                            {
                                sb.AppendLine($"{customPropertyName}={intValue}");
                                break;
                            }

                            sb.AppendLine(((int)property.GetValue(objectToWrite)) == 0
                                ? $"{customPropertyName}="
                                : $"{customPropertyName}={property.GetValue(objectToWrite)}");
                        }
                        else
                            sb.AppendLine($"{customPropertyName}={intValue}"); //Write the int normally.
                        break;
                    case TypeCode.Single:
                        var decimalValue = (float)property.GetValue(objectToWrite);
                        var stringValue = decimalValue.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
                        sb.AppendLine($"{customPropertyName}={stringValue}"); //Write the modified float.
                        break;
                    case TypeCode.String:
                        sb.AppendLine($"{customPropertyName}={property.GetValue(objectToWrite)}");
                        break;
                    case TypeCode.Boolean:
                        var boolValue = (bool)property.GetValue(objectToWrite);
                        sb.AppendLine($"{customPropertyName}={(boolValue ? "true" : "false")}");
                        break;
                    case TypeCode.Object:
                        //Go deeper
                        if (property.PropertyType == typeof(object[]))
                        {
                            sb.AppendLine($"{customPropertyName}[]");
                            continue; //Skip object arrays because all object arrays should be defined as a list.
                        }

                        if (property.PropertyType == typeof(string[]))
                        {
                            var stringArray = (string[])property.GetValue(objectToWrite);
                            if (stringArray.Length == 0)
                            {
                                sb.AppendLine($"{customPropertyName}[]");
                                continue; //Skip empty string arrays
                            }

                            sb.AppendLine($"{customPropertyName}={string.Join(",", stringArray)}");
                            break;
                        }

                        if (!string.IsNullOrEmpty(property.PropertyType.FullName) && property.PropertyType.FullName.Contains("List"))
                        {
                            if (!(property.GetValue(objectToWrite) is IEnumerable<object> list) || !list.Any())
                            {
                                sb.AppendLine($"{customPropertyName}[]");
                                continue; //Skip empty lists.
                            }

                            sb.AppendLine($"{customPropertyName}["); //Start new array definition.
                            var listType = list.GetType().GetGenericArguments()[0];
                            foreach (var o in list)
                            {
                                var customPropertiesForListObject = FindCustomPropertiesReverse(listType);
                                sb.AppendLine("{"); //Start new object definition.
                                WriteObjectToText(ref sb, o, customPropertiesForListObject); //Recursive entry.
                                sb.AppendLine("}"); //Close object.
                            }

                            sb.AppendLine("]"); //Close array.
                            break;
                        }

                        var customPropertiesForInnerObject = FindCustomPropertiesReverse(property.PropertyType);
                        var innerObject = property.GetValue(objectToWrite);
                        sb.AppendLine($"{customPropertyName}{{"); //Start new object definition.
                        WriteObjectToText(ref sb, innerObject, customPropertiesForInnerObject); //Recursive entry.
                        sb.AppendLine("}"); //Close object.
                        break;
                    default:
                        Console.WriteLine($"WARNING Could not write property type: {property.PropertyType} to text for property: {property.Name}");
                        break;
                }
            }
        }

        /// <summary>
        /// Fill the different types of Enum's that are used for specific properties in the character file.
        /// </summary>
        private void FillEnumDictionary()
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
            _propertyToEnumDictionary.Add("Type", typeof(SpawnType));
            _propertyToEnumDictionary.Add("TurretType", typeof(TurretType));
            _propertyToEnumDictionary.Add("Encryption", typeof(EncryptionType));
        }
    }
}