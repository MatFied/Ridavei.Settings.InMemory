using System;

using Ridavei.Settings.Exceptions;

using NUnit.Framework;
using Shouldly;

namespace Ridavei.Settings.InMemory.Tests
{
    [TestFixture]
    public class InMemoryBuilderExtTests
    {
        private readonly static string DictionaryName = "Test";

        [Test]
        public static void UseInMemoryManager__NoException()
        {
            Should.NotThrow(() =>
            {
                SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
            });
        }

        [Test]
        public static void GetSettings_NonExistingDictionary__RaisesException()
        {
            Should.Throw<DictionaryNotFoundException>(() =>
            {
                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                builder.GetSettings(DictionaryName);
            });
        }

        [Test]
        public static void GetOrCreateSettings_NonExistingDictionary__GetSettings()
        {
            Should.NotThrow(() =>
            {
                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                    settings.ShouldNotBeNull();
            });
        }

        [Test]
        public static void GetOrCreateSettings_ExistingDictionary__GetSettings()
        {
            Should.NotThrow(() =>
            {
                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                    settings.ShouldNotBeNull();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                    settings.ShouldNotBeNull();
            });
        }

        [Test]
        public static void Set__NoException()
        {
            Should.NotThrow(() =>
            {
                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                {
                    settings.ShouldNotBeNull();
                    settings.Set("T1", "T2");
                }
            });
        }

        [Test]
        public static void Get__GetValue()
        {
            Should.NotThrow(() =>
            {
                string key = "T1";
                string value = "T2";
                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                {
                    settings.ShouldNotBeNull();
                    settings.Set(key, value);
                    settings.Get(key).ShouldBe(value);
                }
            });
        }

        [Test]
        public static void GetAll_Empty__GetEmptyDictionary()
        {
            Should.NotThrow(() =>
            {
                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                {
                    settings.ShouldNotBeNull();
                    var dict = settings.GetAll();
                    dict.ShouldNotBeNull();
                    dict.Count.ShouldBe(0);
                }
            });
        }

        [Test]
        public static void GetAll__GetDictionary()
        {
            Should.NotThrow(() =>
            {
                string key = "T1";
                string value = "T2";

                var builder = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager();
                using (var settings = builder.GetOrCreateSettings(DictionaryName))
                {
                    settings.ShouldNotBeNull();
                    settings.Set(key, value);
                    var dict = settings.GetAll();
                    dict.ShouldNotBeNull();
                    dict.Count.ShouldBe(1);
                    dict.ContainsKey(key).ShouldBeTrue();
                    dict[key].ShouldBe(value);
                }
            });
        }
    }
}
