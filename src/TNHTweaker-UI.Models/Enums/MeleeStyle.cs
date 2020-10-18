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
        None = 1,

        /// <summary>
        /// Spawns tactical melee weapons.
        /// </summary>
        Tactical = 2,

        /// <summary>
        /// Spawns melee weapons that are tools.
        /// </summary>
        Tool = 4,

        /// <summary>
        /// Spawns improvised melee weapons.
        /// </summary>
        Improvised = 8,

        /// <summary>
        /// Spawns medieval melee weapons.
        /// </summary>
        Medieval = 16,

        /// <summary>
        /// Spawns hand-held shields.
        /// </summary>
        Shield = 32,

        /// <summary>
        /// Spawns power tools.
        /// </summary>
        PowerTool = 64
    }
}