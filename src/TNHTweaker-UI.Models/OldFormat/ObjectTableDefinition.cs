﻿using TNHTweaker_UI.Models.Attributes;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models.OldFormat
{
    /// <summary>
    /// Class that defines an object table.
    /// Object tables are essentially loot pools, which can either be automatically generated based on set parameters, or manually created using IDOverrides.
    /// </summary>
    public class ObjectTableDefinition
    {
        /// <summary>
        /// The file name of the icon to show in the item spawner.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The category of the item that should be spawned in this pool.
        /// </summary>
        public ItemCategory Category { get; set; }

        /// <summary>
        /// This is the minimum ammo capacity of weapons that will be added to the table.
        /// NOTE: If you are spawning something other than weapons in this pool, set this to -1.
        /// </summary>
        public int MinAmmoCapacity { get; set; } = -1;

        /// <summary>
        /// This is the maximum ammo capacity of weapons that will be added to the table.
        /// NOTE: If you are spawning something other than weapons in this pool, set this to -1.
        /// </summary>
        public int MaxAmmoCapacity { get; set; } = -1;

        /// <summary>
        /// Unknown what this does, but set to false by default.
        /// </summary>
        public bool IsBlanked { get; set; }

        /// <summary>
        /// If <c>true</c>, items from this object pool will spawn in a small case.
        /// </summary>
        public bool SpawnsInSmallCase { get; set; }

        /// <summary>
        /// If <c>true</c>, items from this object pool will spawn in a large case
        /// </summary>
        public bool SpawnsInLargeCase { get; set; }

        /// <summary>
        /// If <c>true</c>, this object pool will use items from the <see cref="IDOverride"/> list instead of automatically generating.
        /// </summary>
        [PropertyName("UseIDListOverride")]
        public bool UseIdListOverride { get; set; }

        /// <summary>
        /// A list of Object IDs that will be added to this pool.
        /// </summary>
        [PropertyName("IDOverride")]
        public string[] IdOverride { get; set; }

        /// <summary>
        /// The eras of weaponry to spawn in this pool.
        /// </summary>
        public EraType Eras { get; set; }

        /// <summary>
        /// The object sets of weaponry to spawn in this pool.
        /// </summary>
        public SetType Sets { get; set; }

        /// <summary>
        /// The sizes of weaponry to spawn in this pool.
        /// </summary>
        public WeaponSize Sizes { get; set; }

        /// <summary>
        /// The action types on the weaponry to spawn in this pool.
        /// </summary>
        public WeaponActionType Actions { get; set; }

        /// <summary>
        /// The firing modes on the type of weaponry to spawn in this pool.
        /// </summary>
        public WeaponMode Modes { get; set; }

        /// <summary>
        /// The firing modes that won't spawn in this pool.
        /// </summary>
        public WeaponMode ExcludeModes { get; set; }

        /// <summary>
        /// The feed options of weaponry to spawn in this pool.
        /// </summary>
        [PropertyName("Feedoptions")]
        public FeedOption FeedOptions { get; set; }

        /// <summary>
        /// The mounting types on the weaponry to spawn in this pool.
        /// </summary>
        public MountType MountsAvailable { get; set; }

        /// <summary>
        /// The round powers of the weaponry to spawn in this pool.
        /// </summary>
        public RoundPower RoundPowers { get; set; }

        /// <summary>
        /// The types of attachment features for the attachments to spawn in this pool.
        /// NOTE: This is probably only used if <see cref="Category"/> is <see cref="ItemCategory.Attachment"/>.
        /// </summary>
        public WeaponFeature Features { get; set; }

        /// <summary>
        /// The types of melee styles for melee weapons to spawn in this pool.
        /// </summary>
        public MeleeStyle MeleeStyles { get; set; }

        /// <summary>
        /// The handedness (number of hands used to hold) for melee weapons to spawn in this pool.
        /// </summary>
        public MeleeHandedness MeleeHandedness { get; set; }

        /// <summary>
        /// The types of mounts that can be attached to, for attachments to spawn in this pool.
        /// </summary>
        public MountType MountTypes { get; set; }

        /// <summary>
        /// The types of power-ups to spawn in this pool.
        /// </summary>
        public PowerupType PowerupTypes { get; set; }

        /// <summary>
        /// The types of throwables to spawn in this pool.
        /// </summary>
        public ThrownType ThrownTypes { get; set; }

        /// <summary>
        /// The damage types of throwables to spawn in this pool.
        /// </summary>
        public ThrownDamageType ThrownDamageTypes { get; set; }

        /// <summary>
        /// Unused, but must be declared in the character file.
        /// </summary>
        [PropertyName("Objs")]
        public object[] Objects { get; set; } = new object[0];
    }
}