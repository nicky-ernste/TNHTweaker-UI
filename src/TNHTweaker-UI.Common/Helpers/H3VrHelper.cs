using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using TNHTweaker_UI.Common.Interfaces;

namespace TNHTweaker_UI.Common.Helpers
{
    /// <summary>
    /// Implementation of the <see cref="IH3VrHelper"/> interface.
    /// </summary>
    public class H3VrHelper : IH3VrHelper
    {
        private const string H3VrRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 450540";
        private const string CustomCharactersFolderName = "CustomCharacters";
        private const string IconIdsFileName = "IconIDs.txt";
        private const string ObjectIdsFileName = "ObjectIDs.txt";
        private const string SosigIdsFileName = "SosigIDs.txt";

        public DirectoryInfo FindH3VrDirectory()
        {
            var key = Registry.LocalMachine.OpenSubKey(H3VrRegistryPath);
            return key != null
                ? new DirectoryInfo(key.GetValue("InstallLocation").ToString())
                : null;
        }

        public DirectoryInfo FindTakeAndHoldTweakerCustomCharactersDirectory(string h3VrPath = "")
        {
            var h3VrDirectory = FindH3VrDirectory(h3VrPath);
            if (h3VrDirectory == null)
            {
                return null;
            }

            var customCharacterFolderPath = h3VrDirectory.GetDirectories(CustomCharactersFolderName);
            return customCharacterFolderPath.Any()
                ? customCharacterFolderPath.First()
                : null;
        }

        public List<string> ReadTakeAndHoldIconIds(string h3VrPath = "")
        {
            var h3VrDirectory = FindH3VrDirectory(h3VrPath);
            return h3VrDirectory == null
                ? new List<string>()
                : ReadIdFile(Path.Combine(h3VrDirectory.FullName, CustomCharactersFolderName, IconIdsFileName));
        }

        public List<string> ReadTakeAndHoldObjectIds(string h3VrPath = "")
        {
            var h3VrDirectory = FindH3VrDirectory(h3VrPath);
            return h3VrDirectory == null
                ? new List<string>()
                : ReadIdFile(Path.Combine(h3VrDirectory.FullName, CustomCharactersFolderName, ObjectIdsFileName));
        }

        public List<string> ReadTakeAndHoldSosigIds(string h3VrPath = "")
        {
            var h3VrDirectory = FindH3VrDirectory(h3VrPath);
            return h3VrDirectory == null
                ? new List<string>()
                : ReadIdFile(Path.Combine(h3VrDirectory.FullName, CustomCharactersFolderName, SosigIdsFileName));
        }

        /// <summary>
        /// Reads an ID's text file and returns a list of the ID's found in the file.
        /// </summary>
        /// <param name="pathToFile">The full path to the text file to read.</param>
        /// <returns>A list of ID's. Or an empty list if the file was not found or empty.</returns>
        private List<string> ReadIdFile(string pathToFile)
        {
            var ids = new List<string>();
            try
            {
                var readLines = File.ReadAllLines(pathToFile);
                var filteredIds = readLines.Where(line => !string.IsNullOrEmpty(line.Trim()) && !line.Trim().StartsWith("#")).ToArray(); //Remove empty lines and commented lines.
                ids.AddRange(filteredIds);
            }
            catch (IOException)
            {
                return ids;
            }
            return ids;
        }

        /// <summary>
        /// Attempt to locate the H3VR directory on this system.
        /// Either uses the given <paramref name="h3VrPath"/> or the <see cref="FindH3VrDirectory"/> method.
        /// Also checks if either of these directories exist.
        /// </summary>
        /// <param name="h3VrPath">The path to the H3VR directory that is set directly instead of finding it via the registry.</param>
        /// <returns>A <see cref="DirectoryInfo"/> instance with information about the H3VR installation directory. Or <c>null</c> if it could not be found.</returns>
        private DirectoryInfo FindH3VrDirectory(string h3VrPath)
        {
            DirectoryInfo h3VrDirectory;
            if (string.IsNullOrEmpty(h3VrPath))
            {
                h3VrDirectory = FindH3VrDirectory();
                if (h3VrDirectory == null || !h3VrDirectory.Exists)
                {
                    return null;
                }
            }
            else
            {
                h3VrDirectory = new DirectoryInfo(h3VrPath);
                if (!h3VrDirectory.Exists)
                {
                    return null;
                }
            }

            return h3VrDirectory;
        }
    }
}