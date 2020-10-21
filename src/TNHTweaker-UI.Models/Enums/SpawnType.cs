namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the different type of spawn types for the player.
    /// </summary>
    public enum SpawnType
    {
        /// <summary>
        /// A weapon (firearm) the player can fire.
        /// </summary>
        Firearm = 1,

        /// <summary>
        /// Equipment other than weapons the player can use.
        /// </summary>
        Equipment = 2,

        /// <summary>
        /// Consumable items and power-ups the player can use.
        /// </summary>
        Consumable = 3
    }
}