using TNHTweaker_UI.Models.Attributes;

namespace TNHTweaker_UI.Models.OldFormat
{
    /// <summary>
    /// Class that defines a single patrol.
    /// </summary>
    public class PatrolDefinition
    {
        //TODO Not sure what these types do yet. seems to define two different enemy types that can spawn. But i don't know the difference between EType and LType.
        public string EType { get; set; }
        public string LType { get; set; }

        /// <summary>
        /// The number of enemies in one patrol.
        /// </summary>
        public int PatrolSize { get; set; }

        /// <summary>
        /// The maximum number of patrols active at one time.
        /// </summary>
        public int MaxPatrols { get; set; }

        /// <summary>
        /// The maximum number of patrols active at one time in the limited ammo mode.
        /// </summary>
        [PropertyName("MaxPatrols_LimitedAmmo")]
        public int MaxPatrolsLimitedAmmo { get; set; }

        //TODO Not quite sure what will be regenerating, needs testing.
        public int TimeTilRegen { get; set; }
        [PropertyName("TimeTilRegen_LimitedAmmo")]
        public int TimeTilRegenLimitedAmmo { get; set; }

        /// <summary>
        /// Sets the team that spawned defenders will be on. Default is 1, and the players IFF is 0.
        /// </summary>
        [PropertyName("IFFUsed")]
        public int IffUsed { get; set; } = 1;
    }
}