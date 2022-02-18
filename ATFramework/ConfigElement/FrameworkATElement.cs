using System.Configuration;

namespace ATFramework.ConfigElement;

public class FrameworkATElement : ConfigurationElement
{
    [ConfigurationProperty("name", IsRequired = true)]
    public string Name => (string) this["name"];

    [ConfigurationProperty("aut", IsRequired = true)]
    public string AUT => (string) this["aut"];

    [ConfigurationProperty("browser", IsRequired = true)]
    public string Browser => (string) this["browser"];

    [ConfigurationProperty("testType", IsRequired = true)]
    public string TestType => (string) this["testType"];

    [ConfigurationProperty("isLog", IsRequired = true)]
    public string Islog => (string) this["isLog"];

    [ConfigurationProperty("logPath", IsRequired = true)]
    public string LogPath => (string) this["logPath"];

    [ConfigurationProperty("appDb", IsRequired = true)]
    public string AppDb => (string) base["appDb"];
}