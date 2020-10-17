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
        Uncategorized = 0,

        /// <summary>
        /// Spawns a firearm.
        /// </summary>
        Firearm = 1,

        /// <summary>
        /// Spawns a magazine.
        /// </summary>
        Magazine = 2,

        /// <summary>
        /// Spawns a clip.
        /// </summary>
        Clip = 4,

        /// <summary>
        /// Spawns a cartridge.
        /// </summary>
        Cartridge = 8,

        /// <summary>
        /// Spawns an attachment.
        /// </summary>
        Attachment = 16,

        /// <summary>
        /// Spawns a speed loader.
        /// </summary>
        SpeedLoader = 32,

        /// <summary>
        /// Spawns a thrown weapon.
        /// </summary>
        Thrown = 64,

        /// <summary>
        /// Spawns a melee weapon.
        /// </summary>
        MeleeWeapon = 128,

        /// <summary>
        /// Spawns an explosive.
        /// </summary>
        Explosive = 256,

        /// <summary>
        /// Spawns a power-up.
        /// </summary>
        Powerup = 512,

        /// <summary>
        /// Spawns a target.
        /// </summary>
        Target = 1024,

        /// <summary>
        /// Spawns a tool.
        /// </summary>
        Tool = 2048,

        /// <summary>
        /// Spawns a toy.
        /// </summary>
        Toy = 4096,

        /// <summary>
        /// Spawns a fire work.
        /// </summary>
        Firework = 8192,

        /// <summary>
        /// Spawns an ornament.
        /// </summary>
        Ornament = 16384
    }
}