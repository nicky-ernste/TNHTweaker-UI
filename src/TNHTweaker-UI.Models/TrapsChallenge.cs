using System.Collections.Generic;

namespace TNHTweaker_UI.Models
{
    /// <summary>
    /// Class that defines the traps that will be present in the level.
    /// </summary>
    public class TrapsChallenge
    {
        public IList<TrapDefinition> Traps { get; set; } = new List<TrapDefinition>();
    }
}