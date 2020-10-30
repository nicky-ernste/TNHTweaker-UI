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
        None = 1,

        /// <summary>
        /// Spawns pocket sized weapons.
        /// </summary>
        Pocket = 2,

        /// <summary>
        /// Spawns pistol sized weapons.
        /// </summary>
        Pistol = 4,

        /// <summary>
        /// Spawns compact weapons.
        /// </summary>
        Compact = 8,

        /// <summary>
        /// Spawns carbine sized weapons.
        /// </summary>
        Carbine = 16,

        /// <summary>
        /// Spawns full sized weapons.
        /// </summary>
        FullSize = 32,

        /// <summary>
        /// Spawns bulky weapons.
        /// </summary>
        Bulky = 64,

        /// <summary>
        /// Spawns over sized weapons.
        /// </summary>
        Oversize = 128
    }
}