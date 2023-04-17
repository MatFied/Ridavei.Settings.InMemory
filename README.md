# Ridavei.Settings.InMemory

### Latest release
[![NuGet Badge Ridavei.Settings.InMemory](https://buildstats.info/nuget/Ridavei.Settings.InMemory)](https://www.nuget.org/packages/Ridavei.Settings.InMemory)

Builder extension to store settings keys and values in a [Dictionary<string, string>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2).

## Examples of use

```csharp
using Ridavei.Settings;
using Ridavei.Settings.InMemory;
using Ridavei.Settings.Interfaces;

namespace TestProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            SettingsBuilder settingsBuilder = SettingsBuilder
                .CreateBuilder()
                .UseInMemoryManager();
            using (ISettings settings = settingsBuilder.GetSettings("DictionaryName")
                /*you can use the GetOrCreateSettings method if you are not sure if the settings dictionary exists*/)
            {
                //You can use settings.Get("ExampleKey", "DefaultValue") if you want to retrieve the default value if the key doesn't exists.
                string value = settings.Get("ExampleKey");
                settings.Set("AnotherKey", "NewValue");
            }
        }
    }
}
```