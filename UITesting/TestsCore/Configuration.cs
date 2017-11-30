using System.Configuration;

namespace UITesting.TestsCore
{
    /// <summary>
    /// The class Configuration is used to store the test configuration
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];
    }
}
