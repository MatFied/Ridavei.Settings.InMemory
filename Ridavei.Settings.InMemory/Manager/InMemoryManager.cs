using Ridavei.Settings.Base;
using Ridavei.Settings.InMemory.Settings;
using Ridavei.Settings.Interface;

namespace Ridavei.Settings.InMemory.Manager
{
    /// <summary>
    /// In memory manager class used to retrieve settings using <see cref="InMemorySettings"/>.
    /// </summary>
    internal class InMemoryManager : AManager
    {
        /// <summary>
        /// The default constructor for <see cref="InMemoryManager"/> class.
        /// </summary>
        public InMemoryManager() : base() { }

        /// <summary>
        /// Retrieves the <see cref="ISettings"/> object for the specifed dictionary name.
        /// </summary>
        /// <param name="dictionaryName">Name of the dictionary</param>
        /// <returns>Settings</returns>
        protected override ASettings GetSettingsObject(string dictionaryName)
        {
            return new InMemorySettings(dictionaryName);
        }
    }
}
