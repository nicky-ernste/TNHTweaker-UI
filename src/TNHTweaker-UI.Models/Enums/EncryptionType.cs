namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the different types of encryption that can spawn during the holds.
    /// </summary>
    public enum EncryptionType
    {
        /// <summary>
        /// Spawns static encryption types.
        /// </summary>
        Static = 0,

        /// <summary>
        /// Spawns hardened encryption types.
        /// </summary>
        Hardened = 1,

        /// <summary>
        /// Spawns swarm encryption types.
        /// </summary>
        Swarm = 2,

        /// <summary>
        /// Spawns recursive encryption types.
        /// </summary>
        Recursive = 4,

        /// <summary>
        /// Spawns stealth encryption types.
        /// </summary>
        Stealth = 8,

        /// <summary>
        /// Spawns agile encryption types.
        /// </summary>
        Agile = 16,

        /// <summary>
        /// Spawns regenerative encryption types.
        /// </summary>
        Regenerative = 32,

        /// <summary>
        /// Spawns polymorphic encryption types.
        /// </summary>
        Polymorphic = 64,

        /// <summary>
        /// Spawns cascading encryption types.
        /// </summary>
        Cascading = 128,

        /// <summary>
        /// Spawns orthagonal encryption types.
        /// </summary>
        Orthagonal = 256,

        /// <summary>
        /// Spawns refractive encryption types.
        /// </summary>
        Refractive = 512
    }
}