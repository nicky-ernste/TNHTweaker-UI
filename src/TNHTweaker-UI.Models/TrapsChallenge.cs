﻿using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the traps that will be present in the level.
    /// </summary>
    public class TrapsChallenge
    {
        /// <summary>
        /// The type of traps that will be present.
        /// </summary>
        public TrapType Type { get; set; }

        /// <summary>
        /// The minimum amount of traps that will spawn.
        /// </summary>
        public int MinNumber { get; set; }

        /// <summary>
        /// The maximum amount of traps that will spawn.
        /// </summary>
        public int MaxNumber { get; set; }
    }
}