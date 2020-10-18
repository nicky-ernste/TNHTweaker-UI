using System.Collections.Generic;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the progression levels for a character.
    /// </summary>
    public class ProgressionDefinition
    {
        /// <summary>
        /// The list of levels that the character will go through (in order).
        /// </summary>
        public IList<LevelEntry> Levels { get; set; }
    }
}