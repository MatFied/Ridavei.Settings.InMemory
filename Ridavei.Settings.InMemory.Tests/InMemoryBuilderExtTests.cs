using System;

using NUnit.Framework;
using Shouldly;

namespace Ridavei.Settings.InMemory.Tests
{
    [TestFixture]
    public class InMemoryBuilderExtTests
    {
        [Test]
        public static void UseInMemoryManager__RetrieveSettings()
        {
            Should.NotThrow(() =>
            {
                SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager()
                    .GetSettings("Test")
                    .ShouldNotBeNull();
            });
        }

        [Test]
        public static void UseInMemoryManager_Set__NoException()
        {
            Should.NotThrow(() =>
            {
                var settings = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager()
                    .GetSettings("Test");
                settings.ShouldNotBeNull();
                settings.Set("T1", "T2");
            });
        }

        [Test]
        public static void UseInMemoryManager_Get__GetValue()
        {
            Should.NotThrow(() =>
            {
                string key = "T1";
                string value = "T2";
                var settings = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager()
                    .GetSettings("Test");
                settings.ShouldNotBeNull();
                settings.Set(key, value);
                settings.Get(key).ShouldBe(value);
            });
        }

        [Test]
        public static void UseInMemoryManager_GetAll_Empty__GetEmptyDictionary()
        {
            Should.NotThrow(() =>
            {
                var settings = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager()
                    .GetSettings("Test");
                settings.ShouldNotBeNull();
                var dict = settings.GetAll();
                dict.ShouldNotBeNull();
                dict.Count.ShouldBe(0);
            });
        }

        [Test]
        public static void UseInMemoryManager_GetAll__GetDictionary()
        {
            Should.NotThrow(() =>
            {
                string key = "T1";
                string value = "T2";
                var settings = SettingsBuilder
                    .CreateBuilder()
                    .UseInMemoryManager()
                    .GetSettings("Test");
                settings.ShouldNotBeNull();
                settings.Set(key, value);
                var dict = settings.GetAll();
                dict.ShouldNotBeNull();
                dict.Count.ShouldBe(1);
                dict.ContainsKey(key).ShouldBeTrue();
                dict[key].ShouldBe(value);
            });
        }
    }
}
