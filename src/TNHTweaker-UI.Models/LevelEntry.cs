using TNHTweaker_UI.Models.Attributes;

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
        [PropertyName("NumOverrideTokensForHold")]
        public int NumberOfOverrideTokensForHold { get; set; }

        /// <summary>
        /// The number of additional supply points that will be spawned on top of the normal amount.
        /// </summary>
        [PropertyName("@AdditionalSupplyPoints")]
        public int AdditionalSupplyPoints { get; set; }

        [PropertyName("@MaxBoxesSpawned")]
        public int MaxBoxesSpawned { get; set; }

        [PropertyName("@MinBoxesSpawned")]
        public int MinBoxesSpawned { get; set; }

        [PropertyName("@MaxTokensPerSupply")]
        public int MaxTokensPerSupply { get; set; }

        [PropertyName("@MinTokensPerSupply")]
        public int MinTokensPerSupply { get; set; }

        [PropertyName("@BoxTokenChance")]
        public float BoxTokenChance { get; set; }

        /// <summary>
        /// Definition for defenses that are spawned at the hold point.
        /// </summary>
        public TakeSupplyChallenge TakeChallenge { get; set; }

        /// <summary>
        /// Definition for encryptions and attacking waves during a hold.
        /// </summary>
        public HoldChallenge HoldChallenge { get; set; }

        /// <summary>
        /// Definition for defenses that are spawned at supply points.
        /// </summary>
        public TakeSupplyChallenge SupplyChallenge { get; set; }

        /// <summary>
        /// Definition for the patrols that spawn before the hold.
        /// </summary>
        public PatrolChallenge PatrolChallenge { get; set; }

        /// <summary>
        /// Definition for traps that spawn before the hold.
        /// </summary>
        public TrapsChallenge TrapsChallenge { get; set; }
    }
}