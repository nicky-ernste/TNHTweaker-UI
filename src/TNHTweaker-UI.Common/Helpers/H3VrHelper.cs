using Microsoft.Win32;
using System;
using System.IO;
using TNHTweaker_UI.Common.Interfaces;

namespace TNHTweaker_UI.Common.Helpers
{
    /// <summary>
    /// Implementation of the <see cref="IH3VrHelper"/> interface.
    /// </summary>
    public class H3VrHelper : IH3VrHelper
    {
        private const string h3vrRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 450540";

        public DirectoryInfo FindH3VrDirectory()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(h3vrRegistryPath);
            if (key != null)
            {
                return new DirectoryInfo(key.GetValue("InstallLocation").ToString());
            }
            return null;
        }

        public bool IsTakeAndHoldTweakerInstalled()
        {
            var h3VrDirectory = FindH3VrDirectory();
            if (h3VrDirectory == null)
            {
                return false;
            }
            return true;
        }
    }
}