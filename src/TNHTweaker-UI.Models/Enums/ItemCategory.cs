namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the categories of items that can spawn.
    /// </summary>
    public enum ItemCategory
    {
        /// <summary>
        /// No specific category for an item.
        /// </summary>
        Uncategorized = 1,

        /// <summary>
        /// Spawns a firearm.
        /// </summary>
        Firearm = 2,

        /// <summary>
        /// Spawns a magazine.
        /// </summary>
        Magazine = 4,

        /// <summary>
        /// Spawns a clip.
        /// </summary>
        Clip = 8,

        /// <summary>
        /// Spawns a cartridge.
        /// </summary>
        Cartridge = 16,

        /// <summary>
        /// Spawns an attachment.
        /// </summary>
        Attachment = 32,

        /// <summary>
        /// Spawns a speed loader.
        /// </summary>
        SpeedLoader = 64,

        /// <summary>
        /// Spawns a thrown weapon.
        /// </summary>
        Thrown = 128,

        /// <summary>
        /// Spawns a melee weapon.
        /// </summary>
        MeleeWeapon = 256,

        /// <summary>
        /// Spawns an explosive.
        /// </summary>
        Explosive = 512,

        /// <summary>
        /// Spawns a power-up.
        /// </summary>
        Powerup = 1024,

        /// <summary>
        /// Spawns a target.
        /// </summary>
        Target = 2048,

        /// <summary>
        /// Spawns a tool.
        /// </summary>
        Tool = 4096,

        /// <summary>
        /// Spawns a toy.
        /// </summary>
        Toy = 8192,

        /// <summary>
        /// Spawns a fire work.
        /// </summary>
        Firework = 16384,

        /// <summary>
        /// Spawns an ornament.
        /// </summary>
        Ornament = 32768
    }
}