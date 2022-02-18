using System.Configuration;

namespace ATFramework.ConfigElement;

[ConfigurationCollection(typeof(FrameworkATElement), AddItemName = "testSetting",
    CollectionType = ConfigurationElementCollectionType.BasicMap)]
public class FrameworkATElementCollection : ConfigurationElementCollection
{
    protected override ConfigurationElement CreateNewElement()
    {
        return new FrameworkATElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
        return (element as FrameworkATElement).Name;
    }

    public new FrameworkATElement this[string type] => (FrameworkATElement) base.BaseGet(type);
}