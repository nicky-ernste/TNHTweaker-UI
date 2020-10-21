using System.IO;

namespace TNHTweaker_UI.Common.Interfaces
{
    /// <summary>
    /// Interface that describes helper functions for working with the H3VR game and directories.
    /// </summary>
    public interface IH3VrHelper
    {
        /// <summary>
        /// Attempt to find the directory on the local system where H3VR is installed.
        /// </summary>
        /// <returns>A <see cref="DirectoryInfo"/> object with information about the H3VR location or <c>null</c> if the H3VR installation was not found.</returns>
        DirectoryInfo FindH3VrDirectory();

        /// <summary>
        /// Checks if the take and hold tweaker plugin for BepInEx is installed on this system.
        /// Can only return <c>true</c> if <see cref="FindH3VrDirectory"/> returns a valid path to check.
        /// </summary>
        /// <returns><C>true</C> if the Take and Hold Tweaker plugin in present, <c>false</c> otherwise.</returns>
        bool IsTakeAndHoldTweakerInstalled();
    }
}