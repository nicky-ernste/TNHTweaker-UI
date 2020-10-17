using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines different feeding options for weapons that can spawn.
    /// </summary>
    [Flags]
    public enum FeedOption
    {
        /// <summary>
        /// No specific feeding option set.
        /// </summary>
        None = 0,

        /// <summary>
        /// Spawns breach loaded weapons.
        /// </summary>
        BreachLoad = 1,

        /// <summary>
        /// Spawns weapons with internal magazines.
        /// </summary>
        InternalMag = 2,

        /// <summary>
        /// Spawns weapons with external box magazines.
        /// </summary>
        BoxMag = 4,

        /// <summary>
        /// Spawns weapons that are loaded with stripper clips or individual rounds.
        /// </summary>
        StripperClip = 8,

        /// <summary>
        /// Spawns weapons that are loaded with an Enbloc clip.
        /// </summary>
        EnblocClip = 16
    }
}