using System.Collections.Generic;

namespace TNHTweaker_UI.Models
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
        /// Override what ammo types can be spawned from the ammo spawner.
        /// </summary>
        public IList<string> AmmoOverride { get; set; } = null;

        /// <summary>
        /// Sets the number of magazines or speed loaders the weapon starts with.
        /// </summary>
        public int NumMags { get; set; }

        /// <summary>
        /// Sets the number of bullets a weapon starts with (possibly unused if spawned weapon takes magazines).
        /// </summary>
        public int NumRounds { get; set; }

        /// <summary>
        /// A list of object tables which are used to determine what equipment could possibly spawn.
        /// </summary>
        public IList<ObjectTableDefinition> Tables { get; set; } = new List<ObjectTableDefinition>();
    }
}