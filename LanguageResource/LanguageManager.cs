using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace LanguageResource
{
    /// <summary>
    /// Provides resource manager and culture info.
    /// </summary>
    class LanguageManager
    {
        static readonly ResourceManager _resourceManager = new ResourceManager("LanguageResource.Properties.Resources", Assembly.GetExecutingAssembly());
        static readonly CultureInfo[] _cultures = new CultureInfo[]
            { 
                new CultureInfo("en"),
                new CultureInfo("zh"),
                new CultureInfo("ms")
            };

        /// <summary>
        /// Provides the resource manager to use to access the resources.
        /// </summary>
        public static ResourceManager Resource { get { return _resourceManager; } }

        /// <summary>
        /// Provides the available culture info.
        /// </summary>
        public static ICollection<CultureInfo> Languages { get { return _cultures; } }
    }
}
