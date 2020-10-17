namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the equipment pool for the character.
    /// </summary>
    public class EquipmentPoolDefinition
    {
        /// <summary>
        /// A list of all possible pools that can be spawned.
        /// </summary>
        public PoolEntry[] Entries { get; set; }
    }
}