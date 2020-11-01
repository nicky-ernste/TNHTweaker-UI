using Newtonsoft.Json;
using TNHTweaker_UI.Models.Enums;

namespace TNHTweaker_UI.Models
{
    public class PhaseDefinition
    {
        /// <summary>
        /// The type of encryption that will spawn.
        /// </summary>
        public EncryptionType Encryption { get; set; }

        /// <summary>
        /// The type of sosig to spawn as normal enemies in this phase.
        /// </summary>
        public string EnemyType { get; set; }

        /// <summary>
        /// The type of sosig to spawn as a leader enemy in this phase.
        /// </summary>
        public string LeaderType { get; set; }

        /// <summary>
        /// The minimum amount of encryption targets that will spawn at the end of the phase.
        /// </summary>
        public int MinTargets { get; set; }

        /// <summary>
        /// The maximum amount of encryption targets that will spawn at the end of the phase.
        /// </summary>
        public int MaxTargets { get; set; }

        /// <summary>
        /// The minimum amount of enemies that will spawn per wave.
        /// </summary>
        public int MinEnemies { get; set; }

        /// <summary>
        /// The maximum amount of enemies that will spawn per wave.
        /// </summary>
        public int MaxEnemies { get; set; }

        /// <summary>
        /// The amount of time in between waves of enemies during a phase.
        /// </summary>
        public double SpawnCadence { get; set; }

        /// <summary>
        /// The maximum amount of enemies that can be alive at once during the phase.
        /// Will probably stop spawning new enemies until the alive enemies drop below this limit.
        /// </summary>
        public int MaxEnemiesAlive { get; set; }

        /// <summary>
        /// The maximum amount of directions the player will be attacked from.
        /// </summary>
        public int MaxDirections { get; set; }

        /// <summary>
        /// The amount of time in seconds it takes before the encryption is shown to the player so they can end the phase.
        /// </summary>
        public int ScanTime { get; set; }

        /// <summary>
        /// Probably the amount of time in seconds before enemies start spawning at the start of a phase.
        /// </summary>
        public int WarmUpTime { get; set; }

        /// <summary>
        /// Sets the team that spawned attackers will be on. Default is 1, and the players IFF is 0.
        /// </summary>
        [JsonProperty("IFFUsed")]
        public int IffUsed { get; set; } = 1;

        /// <summary>
        /// The chance that the enemies will throw a grenade at the player.
        /// Value between 0 and 1, which represents a percentage.
        /// </summary>
        public float GrenadeChance { get; set; }

        /// <summary>
        /// The type of grenade the enemies will throw at the player.
        /// </summary>
        public string GrenadeType { get; set; }

        /// <summary>
        /// Determines if enemies should swarm the player.
        /// </summary>
        public bool SwarmPlayer { get; set; }
    }
}