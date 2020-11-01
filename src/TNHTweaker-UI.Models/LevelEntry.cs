using System.Collections.Generic;
using Newtonsoft.Json;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the challenges for a single level in the progression for a character.
    /// </summary>
    public class LevelEntry
    {
        /// <summary>
        /// The number of tokens the character is rewarded for completing the level's <see cref="TakeChallenge"/>.
        /// </summary>
        [JsonProperty("NumOverrideTokensForHold")]
        public int NumberOfOverrideTokensForHold { get; set; }

        /// <summary>
        /// The number of additional supply points that will be spawned on top of the normal amount.
        /// </summary>
        public int AdditionalSupplyPoints { get; set; }

        /// <summary>
        /// The maximum amount of supply boxes to spawn.
        /// </summary>
        public int MaxBoxesSpawned { get; set; }

        /// <summary>
        /// The minimum amount of supply boxes to spawn.
        /// </summary>
        public int MinBoxesSpawned { get; set; }

        /// <summary>
        /// The maximum amount of override tokens that can be found in supply boxes per supply point.
        /// </summary>
        public int MaxTokensPerSupply { get; set; }

        /// <summary>
        /// The minimum amount of override tokens that can be found in supply boxes per supply point.
        /// </summary>
        public int MinTokensPerSupply { get; set; }

        /// <summary>
        /// The percentage chance that a supply token can spawn when breaking a supply box.
        /// Accepts a value between 0 and 1.
        /// </summary>
        public double BoxTokenChance { get; set; }

        /// <summary>
        /// Definition for defenses that are spawned at the hold point.
        /// </summary>
        public TakeSupplyChallenge TakeChallenge { get; set; }

        /// <summary>
        /// Definition for all phases of this hold.
        /// </summary>
        public IList<PhaseDefinition> HoldPhases { get; set; }

        /// <summary>
        /// Definition for defenses that are spawned at supply points.
        /// </summary>
        public TakeSupplyChallenge SupplyChallenge { get; set; }

        /// <summary>
        /// Definition for the patrols that spawn before the hold.
        /// </summary>
        public IList<PatrolDefinition> Patrols { get; set; }
    }
}