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
        public DirectoryInfo FindH3VrDirectory()
        {
            throw new NotImplementedException();
        }

        public bool IsTakeAndHoldTweakerInstalled()
        {
            var h3VrDirectory = FindH3VrDirectory();
            if (h3VrDirectory == null)
                return false;

            return true;
        }
    }
}