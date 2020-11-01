using System.Collections.Generic;
using TNHTweaker_UI.Models.Attributes;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models.OldFormat
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
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="WeaponPrimary"/> object
        /// </summary>
        [PropertyName("Has_Weapon_Primary")]
        public bool HasWeaponPrimary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="WeaponSecondary"/> object
        /// </summary>
        [PropertyName("Has_Weapon_Secondary")]
        public bool HasWeaponSecondary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="WeaponTertiary"/> object
        /// </summary>
        [PropertyName("Has_Weapon_Tertiary")]
        public bool HasWeaponTertiary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="ItemPrimary"/> object
        /// </summary>
        [PropertyName("Has_Item_Primary")]
        public bool HasItemPrimary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="ItemSecondary"/> object
        /// </summary>
        [PropertyName("Has_Item_Secondary")]
        public bool HasItemSecondary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="ItemTertiary"/> object
        /// </summary>
        [PropertyName("Has_Item_Tertiary")]
        public bool HasItemTertiary { get; set; }

        /// <summary>
        /// If <c>true</c>, the player will spawn with an item chosen from the <see cref="ItemShield"/> object
        /// </summary>
        [PropertyName("Has_Item_Shield")]
        public bool HasItemShield { get; set; }

        #region Starting weapon definitions

        /// <summary>
        /// Definition of the primary weapon the character can start with.
        /// </summary>
        [PropertyName("Weapon_Primary")]
        public WeaponDefinition WeaponPrimary { get; set; }

        /// <summary>
        /// Definition of the secondary weapon the character can start with.
        /// </summary>
        [PropertyName("Weapon_Secondary")]
        public WeaponDefinition WeaponSecondary { get; set; }

        /// <summary>
        /// Definition of the tertiary weapon the character can start with.
        /// </summary>
        [PropertyName("Weapon_Tertiary")]
        public WeaponDefinition WeaponTertiary { get; set; }

        /// <summary>
        /// Definition of the primary item the character can start with.
        /// </summary>
        [PropertyName("Item_Primary")]
        public WeaponDefinition ItemPrimary { get; set; }

        /// <summary>
        /// Definition of the secondary item the character can start with.
        /// </summary>
        [PropertyName("Item_Secondary")]
        public WeaponDefinition ItemSecondary { get; set; }

        /// <summary>
        /// Definition of the tertiary item the character can start with.
        /// </summary>
        [PropertyName("Item_Tertiary")]
        public WeaponDefinition ItemTertiary { get; set; }

        /// <summary>
        /// Definition of the shield the character can start with.
        /// </summary>
        [PropertyName("Item_Shield")]
        public WeaponDefinition ItemShield { get; set; }

        #endregion

        /// <summary>
        /// Definition of which items can spawn from the item spawners for this character.
        /// </summary>
        public EquipmentPoolDefinition EquipmentPool { get; set; }

        /// <summary>
        /// Definition of the holds, supplies and patrols.
        /// NOTE: Generally only one <see cref="ProgressionDefinition"/> is actually used.
        /// </summary>
        public IList<ProgressionDefinition> Progressions { get; set; } = new List<ProgressionDefinition>();
    }
}