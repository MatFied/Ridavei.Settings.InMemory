using System;
using System.Collections.Generic;

using Ridavei.Settings.Base;

namespace Ridavei.Settings.InMemory.Settings
{
    /// <summary>
    /// In memory settings class that uses <see cref="Dictionary{TKey, TValue}"/> for storing keys and values.
    /// </summary>
    internal class InMemorySettings : ASettings
    {
        private readonly Dictionary<string, string> keyValues = new Dictionary<string, string>();

        /// <summary>
        /// The default constructor for <see cref="InMemorySettings"/> class.
        /// </summary>
        /// <param name="dictionaryName">Name of the dictionary</param>
        /// <exception cref="ArgumentNullException">Throwed when the name of the dictionary is null, empty or whitespace.</exception>
        public InMemorySettings(string dictionaryName) : base(dictionaryName) { }

        /// <summary>
        /// Sets a new value for the specific key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected override void SetValue(string key, string value)
        {
            keyValues[key] = value;
        }

        /// <summary>
        /// Returns true and the value for the specific key if exists, else return false and null value.
        /// </summary>
        /// <param name="key">Settings key</param>
        /// <param name="value">Returned value</param>
        /// <returns>True if key exists, else false.</returns>
        protected override bool TryGetValue(string key, out string value)
        {
            return keyValues.TryGetValue(key, out value);
        }

        /// <summary>
        /// Returns all keys with their values.
        /// </summary>
        protected override IReadOnlyDictionary<string, string> GetAllValues()
        {
            return keyValues;
        }
    }
}
