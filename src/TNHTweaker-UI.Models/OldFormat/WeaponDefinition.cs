using System.Collections.Generic;
using TNHTweaker_UI.Models.Attributes;

namespace TNHTweaker_UI.Models.OldFormat
{
    /// <summary>
    /// Class that defines a weapon load-out.
    /// </summary>
    public class WeaponDefinition
    {
        /// <summary>
        /// Unused, but must be declared in character file.
        /// </summary>
        public string[] ListOverride { get; set; } = new string[0];

        /// <summary>
        /// Sets the number of magazines or speed loaders the weapon starts with.
        /// </summary>
        [PropertyName("Num_Mags_SL_Clips")]
        public int NumMagsSlClips { get; set; }

        /// <summary>
        /// Sets the number of bullets a weapon starts with (possibly unused if spawned weapon takes magazines).
        /// </summary>
        [PropertyName("Num_Rounds")]
        public int NumRounds { get; set; }

        /// <summary>
        /// A list of object tables which are used to determine what equipment could possibly spawn.
        /// </summary>
        public IList<ObjectTableDefinition> TableDefs { get; set; } = new List<ObjectTableDefinition>();
    }
}