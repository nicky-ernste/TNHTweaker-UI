using Newtonsoft.Json;

namespace TNHTweaker_UI.Models
{
    public class PatrolDefinition
    {
        /// <summary>
        /// The type of sosig to spawn as normal enemies in this patrol.
        /// </summary>
        public string EnemyType { get; set; }

        /// <summary>
        /// The type of sosig to spawn as the leader in this patrol.
        /// </summary>
        public string LeaderType { get; set; }

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
        public int MaxPatrolsLimited { get; set; }

        /// <summary>
        /// Determines how often patrols get spawned before the hold starts.
        /// </summary>
        public double PatrolCadence { get; set; }

        /// <summary>
        /// Determines how often patrols get spawned before the hold starts on limited ammo mode.
        /// </summary>
        public double PatrolCadenceLimited { get; set; }

        /// <summary>
        /// Sets the team that spawned defenders will be on. Default is 1, and the players IFF is 0.
        /// </summary>
        [JsonProperty("IFFUsed")]
        public int IffUsed { get; set; } = 1;

        /// <summary>
        /// Determines if the patrol should swarm the player.
        /// </summary>
        public bool SwarmPlayer { get; set; }

        /// <summary>
        /// How quickly the patrol should assault the player.
        /// </summary>
        [JsonProperty("AssualtSpeed")]
        public string AssaultSpeed { get; set; }

        /// <summary>
        /// The percentage chance that the leader of the patrol will drop something upon being killed.
        /// Accepts a value between 0 and 1.
        /// </summary>
        public double DropChance { get; set; }

        /// <summary>
        /// Determines if the leader can drop health upon being killed.
        /// </summary>
        public bool DropsHealth { get; set; }

        /// <summary>
        /// Determines if the leader can drop a magazine for a gun the player has upon being killed.
        /// </summary>
        public bool DropsMagazine { get; set; }
    }
}