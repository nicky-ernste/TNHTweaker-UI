using TNHTweaker_UI.Models.Attributes;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the options for a take challenge.
    /// </summary>
    public class TakeSupplyChallenge
    {
        /// <summary>
        /// The number of sosig guards that spawn.
        /// </summary>
        public int NumGuards { get; set; }

        /// <summary>
        /// The number of turrets that spawn.
        /// </summary>
        public int NumTurrets { get; set; }

        /// <summary>
        /// Sets the team that spawned defenders will be on. Default is 1, and the players IFF is 0.
        /// </summary>
        [PropertyName("IFFUsed")]
        public int IffUsed { get; set; } = 1;

        /// <summary>
        /// Sets the type of turrets that will spawn as defenses.
        /// </summary>
        public TurretType TurretType { get; set; }

        /// <summary>
        /// Sets the type of sosig defenders that will spawn
        /// </summary>
        [PropertyName("GID")]
        public string EnemyId { get; set; }
    }
}