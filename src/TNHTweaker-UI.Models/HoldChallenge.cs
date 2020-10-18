using System.Collections.Generic;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines that options for all phases of a hold.
    /// </summary>
    public class HoldChallenge
    {
        /// <summary>
        /// Definition of phases for this hold.
        /// </summary>
        public IList<PhaseDefinition> Phases { get; set; }
    }
}