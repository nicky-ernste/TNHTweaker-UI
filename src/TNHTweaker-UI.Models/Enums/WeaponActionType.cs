using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines different action types for weapons that can spawn.
    /// </summary>
    [Flags]
    public enum WeaponActionType
    {
        /// <summary>
        /// No action type limit on spawning.
        /// </summary>
        None = 1,

        /// <summary>
        /// Spawns break action weapons.
        /// </summary>
        BreakAction = 2,

        /// <summary>
        /// Spawns bolt action weapons.
        /// </summary>
        BoltAction = 4,

        /// <summary>
        /// Spawns revolvers.
        /// </summary>
        Revolver = 8,

        /// <summary>
        /// Spawns pump action weapons.
        /// </summary>
        PumpAction = 16,

        /// <summary>
        /// Spawns lever action weapons.
        /// </summary>
        LeverAction = 32,

        /// <summary>
        /// Spawns automatic weapons.
        /// </summary>
        Automatic = 64,

        /// <summary>
        /// Spawns rolling block weapons.
        /// </summary>
        RollingBlock = 128,

        /// <summary>
        /// Spawns open breach weapons.
        /// </summary>
        OpenBreach = 256,

        /// <summary>
        /// Spawns pre-loaded weapons.
        /// </summary>
        PreLoaded = 512,

        /// <summary>
        /// Spawns single action revolvers.
        /// </summary>
        SingleActionRevolver = 1024
    }
}