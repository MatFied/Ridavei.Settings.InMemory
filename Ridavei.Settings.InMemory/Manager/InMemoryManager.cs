using System.Collections.Generic;

using Ridavei.Settings.Base;
using Ridavei.Settings.InMemory.Settings;

namespace Ridavei.Settings.InMemory.Manager
{
    /// <summary>
    /// In memory manager class used to retrieve settings using <see cref="InMemorySettings"/>.
    /// </summary>
    internal class InMemoryManager : AManager
    {
        private readonly Dictionary<string, ASettings> _settings = new Dictionary<string, ASettings>();

        /// <summary>
        /// The default constructor for <see cref="InMemoryManager"/> class.
        /// </summary>
        public InMemoryManager() : base() { }

        /// <inheritdoc/>
        protected override ASettings CreateSettingsObject(string dictionaryName)
        {
            var res = new InMemorySettings(dictionaryName);
            _settings.Add(dictionaryName, res);
            return res;
        }

        /// <inheritdoc/>
        protected override bool TryGetSettingsObject(string dictionaryName, out ASettings settings)
        {
            return _settings.TryGetValue(dictionaryName, out settings);
        }
    }
}
