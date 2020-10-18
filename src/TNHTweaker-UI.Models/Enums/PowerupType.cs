using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines what power-ups can spawn.
    /// </summary>
    [Flags]
    public enum PowerupType
    {
        /// <summary>
        /// Spawns health power-ups
        /// </summary>
        Health = 1,

        /// <summary>
        /// Spawns quad damage power-ups
        /// </summary>
        QuadDamage = 2,

        /// <summary>
        /// Spawns infinite ammo power-ups
        /// </summary>
        InfiniteAmmo = 4,

        /// <summary>
        /// Spawns invincibility power-ups
        /// </summary>
        Invincibility = 8,

        /// <summary>
        /// Spawns ghost mode power-ups
        /// </summary>
        GhostMode = 16,

        /// <summary>
        /// Spawns far out meat power-ups
        /// </summary>
        FarOutMeat = 32,

        /// <summary>
        /// Spawns muscle meats power-ups
        /// </summary>
        MuscleMeat = 64,

        /// <summary>
        /// Spawns home town power-ups
        /// </summary>
        HomeTown = 128,

        /// <summary>
        /// Spawns snake eye power-ups
        /// </summary>
        SnakeEye = 256,

        /// <summary>
        /// Spawns blort power-ups
        /// </summary>
        Blort = 512,

        /// <summary>
        /// Spawns regeneration power-ups
        /// </summary>
        Regen = 1024,

        /// <summary>
        /// Spawns cyclops power-ups
        /// </summary>
        Cyclops = 2048,

        /// <summary>
        /// Spawns wheredigo power-ups
        /// </summary>
        WheredIGo = 4096,

        /// <summary>
        /// Spawns chill out power-ups
        /// </summary>
        ChillOut = 8192,

        /// <summary>
        /// No specific power-up spawns selected.
        /// </summary>
        None = 16384
    }
}