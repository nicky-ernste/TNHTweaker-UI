using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the damage types for thrown weapons that can spawn.
    /// </summary>
    [Flags]
    public enum ThrownDamageType
    {
        /// <summary>
        /// No specific damage type for thrown weapons.
        /// </summary>
        None = 1,

        /// <summary>
        /// Spawns kinetic damage type thrown weapons.
        /// </summary>
        Kinetic = 2,

        /// <summary>
        /// Spawns explosive damage type thrown weapons.
        /// </summary>
        Explosive = 4,

        /// <summary>
        /// Spawns fire damage type thrown weapons.
        /// </summary>
        Fire = 8,

        /// <summary>
        /// Spawns utility damage type thrown weapons.
        /// </summary>
        Utility = 16
    }
}