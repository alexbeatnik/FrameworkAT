using System.Configuration;

namespace ATFramework.ConfigElement;

public class FrameworkATElement : ConfigurationElement
{
    [ConfigurationProperty("name", IsRequired = true)]
    public string Name
    {
        get { return (string) base["name"]; }
    }

    [ConfigurationProperty("aut", IsRequired = true)]
    public string AUT
    {
        get { return (string) base["aut"]; }
    }
    [ConfigurationProperty("browser", IsRequired = true)]
    public string Browser
    {
        get { return (string) base["browser"]; }
    }
    [ConfigurationProperty("testType", IsRequired = true)]
    public string TestType
    {
        get { return (string) base["testType"]; }
    }
    [ConfigurationProperty("isLog", IsRequired = true)]
    public string Islog
    {
        get { return (string) base["isLog"]; }
    }
    [ConfigurationProperty("logPath", IsRequired = true)]
    public string LogPath
    {
        get { return (string) base["appDb"]; }
    }
    [ConfigurationProperty("logPath", IsRequired = true)]
    public string AppDb
    {
        get { return (string) base["appDb"]; }
    }
}