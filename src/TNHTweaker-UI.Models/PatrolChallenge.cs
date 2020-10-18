using System.Collections.Generic;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the patrols that will be roaming around between holds.
    /// </summary>
    public class PatrolChallenge
    {
        public IList<PatrolDefinition> Patrols { get; set; } = new List<PatrolDefinition>();
    }
}