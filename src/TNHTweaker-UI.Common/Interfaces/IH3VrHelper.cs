using System.Collections.Generic;
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
        /// Attempt to find the Take and Hold Tweaker Custom Character directory.
        /// Requires <see cref="FindH3VrDirectory"/> to return the installation path for H3VR.
        /// </summary>
        /// <param name="h3VrPath">Optional direct path to the H3VR directory. Use this if <see cref="FindH3VrDirectory"/> cannot find the installation path.</param>
        /// <returns>A <see cref="DirectoryInfo"/> object with information about the Take and Hold Tweaker Custom Characters directory, or <c>null</c> if the H3VR or custom characters directory was not found.</returns>
        DirectoryInfo FindTakeAndHoldTweakerCustomCharactersDirectory(string h3VrPath = "");

        /// <summary>
        /// Reads the list of Icon ID's of the Take and Hold game mode.
        /// </summary>
        /// <param name="h3VrPath">Optional direct path to the H3VR directory. Use this if <see cref="FindH3VrDirectory"/> cannot find the installation path.</param>
        /// <returns>A list of Icon ID's. Or an empty list if the file was not found or empty.</returns>
        List<string> ReadTakeAndHoldIconIds(string h3VrPath = "");

        /// <summary>
        /// Reads the list of Object ID's of the Take and Hold game mode.
        /// </summary>
        /// <param name="h3VrPath">Optional direct path to the H3VR directory. Use this if <see cref="FindH3VrDirectory"/> cannot find the installation path.</param>
        /// <returns>A list of Object ID's. Or an empty list if the file was not found or empty.</returns>
        List<string> ReadTakeAndHoldObjectIds(string h3VrPath = "");

        /// <summary>
        /// Reads the list of Sosig ID's of the Take and Hold game mode.
        /// </summary>
        /// <param name="h3VrPath">Optional direct path to the H3VR directory. Use this if <see cref="FindH3VrDirectory"/> cannot find the installation path.</param>
        /// <returns>A list of Sosig ID's. Or an empty list if the file was not found or empty.</returns>
        List<string> ReadTakeAndHoldSosigIds(string h3VrPath = "");
    }
}