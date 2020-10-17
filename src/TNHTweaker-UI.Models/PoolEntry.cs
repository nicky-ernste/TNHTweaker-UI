using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines a single equipment pool entry.
    /// </summary>
    public class PoolEntry
    {
        /// <summary>
        /// This determines where a pool will show up in the item spawner.
        /// </summary>
        public SpawnType Type { get; set; }

        /// <summary>
        /// Cost of purchasing an item from this pool.
        /// </summary>
        public int TokenCost { get; set; }

        /// <summary>
        /// Cost of purchasing an item from this pool when playing on limited ammo mode.
        /// </summary>
        public int TokenCost_Limited { get; set; }

        /// <summary>
        /// The level that this pool can start appearing at.
        /// NOTE: levels start at 0;
        /// </summary>
        public int MinLevelAppears { get; set; }

        /// <summary>
        /// The highest level that this pool can appear at.
        /// NOTE: levels start at 0;
        /// </summary>
        public int MaxLevelAppears { get; set; }

        /// <summary>
        /// Sets how likely this pool is to appear. Default is usually 1, and higher values represent rarer pools.
        /// </summary>
        public int Rarity { get; set; } = 1;

        /// <summary>
        /// The object table which determines what kinds of weapons can spawn from this pool entry.
        /// </summary>
        public ObjectTableDefinition TableDef { get; set; }
    }
}