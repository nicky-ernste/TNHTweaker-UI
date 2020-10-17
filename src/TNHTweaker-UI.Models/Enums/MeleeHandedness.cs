using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the handedness of the melee weapons that can spawn.
    /// </summary>
    [Flags]
    public enum MeleeHandedness
    {
        /// <summary>
        /// No specific type of handedness.
        /// </summary>
        None = 0,

        /// <summary>
        /// Spawns one handed melee weapons.
        /// </summary>
        OneHanded = 1,

        /// <summary>
        /// Spawns two handed melee weapons.
        /// </summary>
        TwoHanded = 2
    }
}