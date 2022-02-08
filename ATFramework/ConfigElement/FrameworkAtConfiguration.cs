using System.Configuration;

namespace ATFramework.ConfigElement;

public class FrameworkAtConfiguration : ConfigurationSection
{
    private static FrameworkAtConfiguration _testConfig =
        (FrameworkAtConfiguration) ConfigurationManager.GetSection("FrameworkConfiguration");

    public static FrameworkAtConfiguration FSettings
    {
        get { return _testConfig; }
    }

    [ConfigurationProperty("testSettings")]
    public FrameworkATElementCollection TestSettings
    {
        get { return (FrameworkATElementCollection) base["testSettings"]; }
    }
}