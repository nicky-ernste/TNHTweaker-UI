namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines what types of turrets that can spawn.
    /// </summary>
    public enum TurretType
    {
        /// <summary>
        /// Spawns SMG turrets.
        /// </summary>
        SMG = 1,

        /// <summary>
        /// Spawns Flak turrets.
        /// </summary>
        FLAK = 2,

        /// <summary>
        /// Spawns Machine gun turrets.
        /// </summary>
        Machinegun = 4,

        /// <summary>
        /// Spawns Flamethrower turrets.
        /// </summary>
        Flamethrower = 8,

        /// <summary>
        /// Spawns Suppression turrets.
        /// </summary>
        Suppression = 16
    }
}