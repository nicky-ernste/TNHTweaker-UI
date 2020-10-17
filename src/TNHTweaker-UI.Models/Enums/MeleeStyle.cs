using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class the defines the different styles of melee weapons that can spawn.
    /// </summary>
    [Flags]
    public enum MeleeStyle
    {
        /// <summary>
        /// No specific type of melee weapon.
        /// </summary>
        None = 0,

        /// <summary>
        /// Spawns tactical melee weapons.
        /// </summary>
        Tactical = 1,

        /// <summary>
        /// Spawns melee weapons that are tools.
        /// </summary>
        Tool = 2,

        /// <summary>
        /// Spawns improvised melee weapons.
        /// </summary>
        Improvised = 4,

        /// <summary>
        /// Spawns medieval melee weapons.
        /// </summary>
        Medieval = 8,

        /// <summary>
        /// Spawns hand-held shields.
        /// </summary>
        Shield = 16,

        /// <summary>
        /// Spawns power tools.
        /// </summary>
        PowerTool = 32
    }
}