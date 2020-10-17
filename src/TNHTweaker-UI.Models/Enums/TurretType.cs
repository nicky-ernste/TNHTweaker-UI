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
        SMG = 0,

        /// <summary>
        /// Spawns Flak turrets.
        /// </summary>
        FLAK = 1,

        /// <summary>
        /// Spawns Machine gun turrets.
        /// </summary>
        Machinegun = 2,

        /// <summary>
        /// Spawns Flamethrower turrets.
        /// </summary>
        Flamethrower = 4,

        /// <summary>
        /// Spawns Suppression turrets.
        /// </summary>
        Suppression = 8
    }
}