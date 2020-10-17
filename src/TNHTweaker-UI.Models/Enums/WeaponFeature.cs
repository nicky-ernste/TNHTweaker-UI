using System;

namespace TNHTweaker_UI.Models.Enums
{
    /// <summary>
    /// Enum class that defines the attachment types that are available for weapons that spawn.
    /// </summary>
    [Flags]
    public enum WeaponFeature
    {
        /// <summary>
        /// No specific attachment types selected.
        /// </summary>
        None = 0,

        /// <summary>
        /// Allows spawning of loose iron sights.
        /// </summary>
        IronSight = 1,

        /// <summary>
        /// Allows spawning of magnifying optics.
        /// </summary>
        Magnification = 2,

        /// <summary>
        /// Allows spawning of reflex type optics.
        /// </summary>
        Reflex = 4,

        /// <summary>
        /// Allows spawning of suppressors and noise dampening muzzle devices.
        /// </summary>
        Suppression = 8,

        /// <summary>
        /// Allows spawning of stocks.
        /// </summary>
        Stock = 16,

        /// <summary>
        /// Allows spawning of laser pointers.
        /// </summary>
        Laser = 32,

        /// <summary>
        /// Allows spawning of flashlights.
        /// </summary>
        Illumination = 64,

        /// <summary>
        /// Allows spawning of grips.
        /// </summary>
        Grip = 128,

        /// <summary>
        /// Allows spawning of decoration attachments.
        /// </summary>
        Decoration = 256,

        /// <summary>
        /// Allows spawning of muzzle breaks and other recoil mitigating devices.
        /// </summary>
        RecoilMitigation = 512,

        /// <summary>
        /// Allows spawning of barrel extensions.
        /// </summary>
        BarrelExtension = 1024,

        /// <summary>
        /// Allows spawning of rail adapters.
        /// </summary>
        Adapter = 2048,

        /// <summary>
        /// Allows spawning of bayonets.
        /// </summary>
        Bayonet = 4096,

        /// <summary>
        /// Allows spawning of under-barrel or other projectile weapon attachments.
        /// </summary>
        ProjectileWeapon = 8192,

        /// <summary>
        /// Allows spawning of bi-pods.
        /// </summary>
        Bipod = 16384
    }
}