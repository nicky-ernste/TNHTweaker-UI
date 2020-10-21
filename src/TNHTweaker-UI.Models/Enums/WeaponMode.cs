using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the different firing modes for weapons that can spawn.
    /// </summary>
    [Flags]
    public enum WeaponMode
    {
        /// <summary>
        /// No specific limit on fire mode.
        /// </summary>
        None = 1,

        /// <summary>
        /// Spawns semi automatic weapons.
        /// </summary>
        SemiAuto = 2,

        /// <summary>
        /// Spawns burst fire weapons.
        /// </summary>
        Burst = 4,

        /// <summary>
        /// Spawns fully automatic weapons.
        /// </summary>
        FullAuto = 8,

        /// <summary>
        /// Spawns single fire weapons.
        /// </summary>
        SingleFire = 16
    }
}