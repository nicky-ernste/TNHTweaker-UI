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
        None = 0,

        /// <summary>
        /// Spawns semi automatic weapons.
        /// </summary>
        SemiAuto = 1,

        /// <summary>
        /// Spawns burst fire weapons.
        /// </summary>
        Burst = 2,

        /// <summary>
        /// Spawns fully automatic weapons.
        /// </summary>
        FullAuto = 4,

        /// <summary>
        /// Spawns single fire weapons.
        /// </summary>
        SingleFire = 8
    }
}