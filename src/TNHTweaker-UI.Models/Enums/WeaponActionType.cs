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
        None = 0,

        /// <summary>
        /// Spawns break action weapons.
        /// </summary>
        BreakAction = 1,

        /// <summary>
        /// Spawns bolt action weapons.
        /// </summary>
        BoltAction = 2,

        /// <summary>
        /// Spawns revolvers.
        /// </summary>
        Revolver = 4,

        /// <summary>
        /// Spawns pump action weapons.
        /// </summary>
        PumpAction = 8,

        /// <summary>
        /// Spawns lever action weapons.
        /// </summary>
        LeverAction = 16,

        /// <summary>
        /// Spawns automatic weapons.
        /// </summary>
        Automatic = 32,

        /// <summary>
        /// Spawns rolling block weapons.
        /// </summary>
        RollingBlock = 64,

        /// <summary>
        /// Spawns open breach weapons.
        /// </summary>
        OpenBreach = 128,

        /// <summary>
        /// Spawns pre-loaded weapons.
        /// </summary>
        PreLoaded = 256,

        /// <summary>
        /// Spawns single action revolvers.
        /// </summary>
        SingleActionRevolver = 512
    }
}