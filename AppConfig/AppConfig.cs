using System;
using System.Collections.Specialized;
using LanguageExt;
using static LanguageExt.Prelude;

// Write implementations for the methods in the `AppConfig` class
// below. (For both methods, a reasonable one-line method body is possible.
// Assume settings are of type string, numeric or date.) Can this
// implementation help you to test code that relies on settings in a
// `.config` file?

namespace AppConfig
{
    public class AppConfig
    {
        readonly NameValueCollection source;

        public AppConfig() : this(ConfigurationManager.AppSettings) { }
        public AppConfig(NameValueCollection source)
        {
            this.source = source;
        }

        public Option<T> Get<T>(string key)
                => source[key] == null
                    ? None
                    : Some((T)Convert.ChangeType(source[key], typeof(T)));
        public T Get<T>(string key, T defaultValue)
                => Get<T>(key).Match
                    (
                    () => defaultValue,
                    (value) => value.Head
                    );
    }
    public abstract class ConfigurationManager
    {
        public static NameValueCollection AppSettings => null;
    }
    public class Tester
    {

        static void Main()
        {
            ;
        }
    }
}
