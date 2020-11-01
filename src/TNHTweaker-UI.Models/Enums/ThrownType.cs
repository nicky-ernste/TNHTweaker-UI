using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the types of thrown weapons that can be spawned.
    /// </summary>
    [Flags]
    public enum ThrownType
    {
        /// <summary>
        /// No specific thrown types will be spawned.
        /// </summary>
        None = 1,

        /// <summary>
        /// Spawns thrown weapons with a manual fuse.
        /// </summary>
        ManualFuse = 2,

        /// <summary>
        /// Spawns thrown weapons with a pin.
        /// </summary>
        Pinned = 4,

        /// <summary>
        /// Spawns thrown weapons with a strange mechanism.
        /// </summary>
        Strange = 8
    }
}