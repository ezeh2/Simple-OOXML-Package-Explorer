namespace PackageExplorer.Configuration
{
    using System;
    using System.Configuration;

    class PartViewerSettingsCollection : ConfigurationElementCollection
    {
        public new PartViewerSettings this[string name]
        {
            get { return (PartViewerSettings)base.BaseGet(name); }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new PartViewerSettings(elementName);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PartViewerSettings();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PartViewerSettings)element).Name;
        }
    }
}
