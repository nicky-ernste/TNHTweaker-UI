using System.Collections.Generic;

namespace TNHTweaker_UI.Models.OldFormat
{
    /// <summary>
    /// Class that defines the equipment pool for the character.
    /// </summary>
    public class EquipmentPoolDefinition
    {
        /// <summary>
        /// A list of all possible pools that can be spawned.
        /// </summary>
        public IList<PoolEntry> Entries { get; set; } = new List<PoolEntry>();
    }
}