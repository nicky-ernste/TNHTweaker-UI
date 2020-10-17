using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines different mounting options for accessories for spawned weapons.
    /// </summary>
    [Flags]
    public enum MountType
    {
        /// <summary>
        /// No specific mounting options selected.
        /// </summary>
        None = 0,

        /// <summary>
        /// Spawns weapons that have Picatinny rails.
        /// </summary>
        Picatinny = 1,

        /// <summary>
        /// Spawns weapons that have russian optic mounts.
        /// </summary>
        Russian = 2,

        /// <summary>
        /// Spawns weapons that can take muzzle attachments.
        /// </summary>
        Muzzle = 4,

        /// <summary>
        /// Spawns weapons that can take stock attachments.
        /// </summary>
        Stock = 8,

        /// <summary>
        /// Spawns weapons that have their own unique attachments.
        /// </summary>
        Bespoke = 16
    }
}