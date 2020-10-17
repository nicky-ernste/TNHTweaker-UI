using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Base class that defines all the properties of a custom character.
    /// </summary>
    public class CharacterInfo
    {
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The group or category the character will appear in.
        /// </summary>
        public CharacterGroup Group { get; set; }

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
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Weapon_Primary"/> object
        /// </summary>
        public bool HasWeaponPrimary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Weapon_Secondary"/> object
        /// </summary>
        public bool HasWeaponSecondary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Weapon_Tertiary"/> object
        /// </summary>
        public bool HasWeaponTertiary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Item_Primary"/> object
        /// </summary>
        public bool HasItemPrimary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Item_Secondary"/> object
        /// </summary>
        public bool HasItemSecondary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Item_Tertiary"/> object
        /// </summary>
        public bool HasItemTertiary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="Item_Shield"/> object
        /// </summary>
        public bool HasItemShield { get; set; }

        #region Starting weapon definitions

        /// <summary>
        /// Definition of the primary weapon the character can start with.
        /// </summary>
        public WeaponDefinition Weapon_Primary { get; set; }

        /// <summary>
        /// Definition of the secondary weapon the character can start with.
        /// </summary>
        public WeaponDefinition Weapon_Secondary { get; set; }

        /// <summary>
        /// Definition of the tertiary weapon the character can start with.
        /// </summary>
        public WeaponDefinition Weapon_Tertiary { get; set; }

        /// <summary>
        /// Definition of the primary item the character can start with.
        /// </summary>
        public WeaponDefinition Item_Primary { get; set; }

        /// <summary>
        /// Definition of the secondary item the character can start with.
        /// </summary>
        public WeaponDefinition Item_Secondary { get; set; }

        /// <summary>
        /// Definition of the tertiary item the character can start with.
        /// </summary>
        public WeaponDefinition Item_Tertiary { get; set; }

        /// <summary>
        /// Definition of the shield the character can start with.
        /// </summary>
        public WeaponDefinition Item_Shield { get; set; }

        #endregion

        /// <summary>
        /// Definition of which items can spawn from the item spawners for this character.
        /// </summary>
        public EquipmentPoolDefinition EquipmentPool { get; set; }

        /// <summary>
        /// Definition of the holds, supplies and patrols.
        /// NOTE: Generally only one <see cref="ProgressionDefinition"/> is actually used.
        /// </summary>
        public ProgressionDefinition[] Progressions { get; set; }
    }
}