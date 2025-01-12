using System.Configuration;

namespace SeleniumTests.Helpers
{
    /// <summary>
    /// Configuration Helper
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Reads property from config file
        /// </summary>
        /// <typeparam name="T">
        /// Type of the target property
        /// </typeparam>
        /// <param name="name">
        /// Name of the target property
        /// </param>
        /// <returns>
        /// Property read from config
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static T Get<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name] ??
                throw new InvalidOperationException($"{name} was not found. Please check configuration file.");

            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
