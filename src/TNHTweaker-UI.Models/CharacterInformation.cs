using System.Collections.Generic;
using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Base class that defines all the properties of a custom character.
    /// </summary>
    public class CharacterInformation
    {
        #region Base Properties.

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A unique ID for the custom character.
        /// </summary>
        [JsonProperty("CharacterID")]
        public int CharacterId { get; set; }

        /// <summary>
        /// Unique id for this table.
        /// </summary>
        [JsonProperty("TableID")]
        public string TableId { get; set; }

        /// <summary>
        /// The group or category the character will appear in.
        /// </summary>
        public CharacterGroup CharacterGroup { get; set; }

        /// <summary>
        /// The name of the character icon.
        /// </summary>
        public string CharacterIconName { get; set; }

        /// <summary>
        /// The number of override tokens the character starts with.
        /// </summary>
        public int StartingTokens { get; set; }

        /// <summary>
        /// Unknown what this does, but is normally set to false.
        /// </summary>
        public bool ForceAllAgentWeapons { get; set; }

        /// <summary>
        /// More extensive description of the character.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If <c>true</c>, then when the player purchases an item it costs one more token to purchase that item again.
        /// </summary>
        public bool UsesPurchasePriceIncrement { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="PrimaryWeapon"/> object
        /// </summary>
        public bool HasPrimaryWeapon { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="SecondaryWeapon"/> object
        /// </summary>
        public bool HasSecondaryWeapon { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="TertiaryWeapon"/> object
        /// </summary>
        public bool HasTertiaryWeapon { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="PrimaryItem"/> object
        /// </summary>
        public bool HasPrimaryItem { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="SecondaryItem"/> object
        /// </summary>
        public bool HasSecondaryItem { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="TertiaryItem"/> object
        /// </summary>
        public bool HasTertiaryItem { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Shield"/> object
        /// </summary>
        public bool HasShield { get; set; }

        /// <summary>
        /// Allows spawning of specific ammo from the given era's.
        /// </summary>
        public EraType ValidAmmoEras { get; set; }

        /// <summary>
        /// Allows spawning of specific ammo from the given sets.
        /// </summary>
        public SetType ValidAmmoSets { get; set; }

        #endregion

        #region Starting weapon definitions

        /// <summary>
        /// Definition of the primary weapon the character can start with.
        /// </summary>
        public WeaponDefinition PrimaryWeapon { get; set; }

        /// <summary>
        /// Definition of the secondary weapon the character can start with.
        /// </summary>
        public WeaponDefinition SecondaryWeapon { get; set; }

        /// <summary>
        /// Definition of the tertiary weapon the character can start with.
        /// </summary>
        public WeaponDefinition TertiaryWeapon { get; set; }

        /// <summary>
        /// Definition of the primary item the character can start with.
        /// </summary>
        public WeaponDefinition PrimaryItem { get; set; }

        /// <summary>
        /// Definition of the secondary item the character can start with.
        /// </summary>
        public WeaponDefinition SecondaryItem { get; set; }

        /// <summary>
        /// Definition of the tertiary item the character can start with.
        /// </summary>
        public WeaponDefinition TertiaryItem { get; set; }

        /// <summary>
        /// Definition of the shield the character can start with.
        /// </summary>
        public WeaponDefinition Shield { get; set; }

        #endregion

        /// <summary>
        /// Not quite sure what this is for yet. But it seems that it will spawn sights or tells the game to include certain sights?
        /// </summary>
        public ObjectTableDefinition RequireSightTable { get; set; }

        /// <summary>
        /// Definition of which items can spawn from the item spawners for this character.
        /// </summary>
        public IList<EquipmentPoolDefinition> EquipmentPools { get; set; }

        /// <summary>
        /// Definition of the holds, supplies and patrols, for 5 holds mode.
        /// </summary>
        public IList<LevelEntry> Levels { get; set; }

        /// <summary>
        /// Definition of the holds, supplies and patrols, for endless mode
        /// </summary>
        public IList<LevelEntry> LevelsEndless { get; set; }
    }
}