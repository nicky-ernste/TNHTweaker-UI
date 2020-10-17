using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the different Era's weapons and equipment can be from.
    /// </summary>
    [Flags]
    public enum EraType
    {
        /// <summary>
        /// No specific era is defined.
        /// </summary>
        None = 0,

        /// <summary>
        /// Defines weapons and equipment from the Colonial era.
        /// </summary>
        Colonial = 1,

        /// <summary>
        /// Defines weapons and equipment from the Wild West era.
        /// </summary>
        WildWest = 2,

        /// <summary>
        /// Defines weapons and equipment from the Turn of the Century era.
        /// </summary>
        TurnOfTheCentury = 4,

        /// <summary>
        /// Defines weapons and equipment from the World War 1 era.
        /// </summary>
        WW1 = 8,

        /// <summary>
        /// Defines weapons and equipment from the World War 2 era.
        /// </summary>
        WW2 = 16,

        /// <summary>
        /// Defines weapons and equipment from the Post World War 2 era.
        /// </summary>
        PostWar = 32,

        /// <summary>
        /// Defines weapons and equipment from the Modern era.
        /// </summary>
        Modern = 64,

        /// <summary>
        /// Defines weapons and equipment from the Futuristic era.
        /// </summary>
        Futuristic = 128,

        /// <summary>
        /// Defines weapons and equipment from the Medieval era.
        /// </summary>
        Medieval = 256
    }
}