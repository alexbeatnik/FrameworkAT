using System.Configuration;

namespace ATFramework.ConfigElement;

public class FrameworkATElement : ConfigurationElement
{
    [ConfigurationProperty("name", IsRequired = true)]
    public string Name
    {
        get { return (string) this["name"]; }
    }

    [ConfigurationProperty("aut", IsRequired = true)]
    public string AUT
    {
        get { return (string) this["aut"]; }
    }
    [ConfigurationProperty("browser", IsRequired = true)]
    public string Browser
    {
        get { return (string) this["browser"]; }
    }
    [ConfigurationProperty("testType", IsRequired = true)]
    public string TestType
    {
        get { return (string) this["testType"]; }
    }
    [ConfigurationProperty("isLog", IsRequired = true)]
    public string Islog
    {
        get { return (string) this["isLog"]; }
    }
    [ConfigurationProperty("logPath", IsRequired = true)]
    public string LogPath
    {
        get { return (string) this["logPath"]; }
    }
    [ConfigurationProperty("appDb", IsRequired = true)]
    public string AppDb
    {
        get { return (string) base["appDb"]; }
    }
}