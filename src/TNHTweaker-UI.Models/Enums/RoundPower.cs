using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that describes the power of the weapons that spawn.
    /// </summary>
    [Flags]
    public enum RoundPower
    {
        /// <summary>
        /// No specific selection for weapon power.
        /// </summary>
        None = 0,

        /// <summary>
        /// Spawns weapons with small calibers.
        /// </summary>
        Tiny = 1,

        /// <summary>
        /// Spawns weapons with pistol calibers.
        /// </summary>
        Pistol = 2,

        /// <summary>
        /// Spawns weapons with shotgun calibers.
        /// </summary>
        Shotgun = 4,

        /// <summary>
        /// Spawns weapons with intermediate power calibers.
        /// </summary>
        Intermediate = 8,

        /// <summary>
        /// Spawns weapons with full power calibers.
        /// </summary>
        FullPower = 16,

        /// <summary>
        /// Spawns weapons with anti material calibers.
        /// </summary>
        AntiMaterial = 32,

        /// <summary>
        /// Spawns weapons with ordinance (explosive) calibers.
        /// </summary>
        Ordinance = 64,

        /// <summary>
        /// Spawns weapons with exotic calibers.
        /// </summary>
        Exotic = 128,

        /// <summary>
        /// Spawns weapons that use fire.
        /// </summary>
        Fire = 256
    }
}