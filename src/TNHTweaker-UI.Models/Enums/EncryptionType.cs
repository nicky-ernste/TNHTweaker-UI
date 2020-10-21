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
        Static = 1,

        /// <summary>
        /// Spawns hardened encryption types.
        /// </summary>
        Hardened = 2,

        /// <summary>
        /// Spawns swarm encryption types.
        /// </summary>
        Swarm = 4,

        /// <summary>
        /// Spawns recursive encryption types.
        /// </summary>
        Recursive = 8,

        /// <summary>
        /// Spawns stealth encryption types.
        /// </summary>
        Stealth = 16,

        /// <summary>
        /// Spawns agile encryption types.
        /// </summary>
        Agile = 32,

        /// <summary>
        /// Spawns regenerative encryption types.
        /// </summary>
        Regenerative = 64,

        /// <summary>
        /// Spawns polymorphic encryption types.
        /// </summary>
        Polymorphic = 128,

        /// <summary>
        /// Spawns cascading encryption types.
        /// </summary>
        Cascading = 256,

        /// <summary>
        /// Spawns orthagonal encryption types.
        /// </summary>
        Orthagonal = 512,

        /// <summary>
        /// Spawns refractive encryption types.
        /// </summary>
        Refractive = 1024
    }
}