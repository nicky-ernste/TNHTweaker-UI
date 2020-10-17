using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the overall size of weapons that can spawn.
    /// </summary>
    [Flags]
    public enum WeaponSize
    {
        /// <summary>
        /// No specific size limit.
        /// </summary>
        None = 0,

        /// <summary>
        /// Spawns pocket sized weapons.
        /// </summary>
        Pocket = 1,

        /// <summary>
        /// Spawns pistol sized weapons.
        /// </summary>
        Pistol = 2,

        /// <summary>
        /// Spawns compact weapons.
        /// </summary>
        Compact = 4,

        /// <summary>
        /// Spawns carbine sized weapons.
        /// </summary>
        Carbine = 8,

        /// <summary>
        /// Spawns full sized weapons.
        /// </summary>
        FullSize = 16,

        /// <summary>
        /// Spawns bulky weapons.
        /// </summary>
        Bulky = 32,

        /// <summary>
        /// Spawns over sized weapons.
        /// </summary>
        OverSize = 64,

        /// <summary>
        /// Spawns all sizes of weapons.
        /// </summary>
        All = 128
    }
}