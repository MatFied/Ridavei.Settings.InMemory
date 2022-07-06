# Ridavei.Settings.InMemory

Builder extension to store settings keys and values in a Dictionary<string, string>.

## Examples of use

```csharp
using Ridavei.Settings;
using Ridavei.Settings.Interface;
using Ridavei.Settings.InMemory;

namespace TestProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (ISettings settings = SettingsBuilder.CreateBuilder())
            {
                settings
                    .UseInMemoryManager()
                    .GetSettings("DictionaryName");

                //You can use settings.Get("ExampleKey", "DefaultValue") if you want to retrieve the default value if the key doesn't exists.
                string value = settings.Get("ExampleKey");
                settings.Set("AnotherKey", "NewValue");
            }
        }
    }
}
```