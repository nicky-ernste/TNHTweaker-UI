using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines different kinds of sets of weapons and equipment that can spawn.
    /// </summary>
    [Flags]
    public enum SetType
    {
        /// <summary>
        /// Mainly real-life weapons and equipment.
        /// </summary>
        Real = 0,

        /// <summary>
        /// Mainly fictional weapons and equipment that could really exist today.
        /// </summary>
        GroundedFictional = 1,

        /// <summary>
        /// Mainly fictional weapons and equipment that don't exist or are SciFi.
        /// </summary>
        SciFiFictional = 2,

        /// <summary>
        /// Mainly meme and other crazy weapons and equipment.
        /// </summary>
        Meme = 4,

        /// <summary>
        /// Mainly weapons and equipment used in Meat Fortress.
        /// </summary>
        MF = 8,

        /// <summary>
        /// Mainly weapons and equipment that were added in Holiday updates?
        /// </summary>
        Holiday = 16,

        /// <summary>
        /// Mainly weapons and equipment that are used in Take and Hold?
        /// </summary>
        TNH = 32
    }
}