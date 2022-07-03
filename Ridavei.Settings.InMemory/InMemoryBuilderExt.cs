using Ridavei.Settings.InMemory.Manager;

namespace Ridavei.Settings.InMemory
{
    /// <summary>
    /// Class used to extend <see cref="SettingsBuilder"/>.
    /// </summary>
    public static class InMemoryBuilderExt
    {
        /// <summary>
        /// Allows to use <see cref="InMemoryManager"/> as the manager class.
        /// </summary>
        /// <param name="builder">Builder</param>
        /// <returns>Builder</returns>
        public static SettingsBuilder UseInMemoryManager(this SettingsBuilder builder)
        {
            return builder.SetManager(new InMemoryManager());
        }
    }
}
