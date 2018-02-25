namespace PackageExplorer.Configuration
{
    using System;
    using System.Configuration;

    class PackageContentTypeSettingsCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new PackageContentTypeSettings(elementName);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PackageContentTypeSettings();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PackageContentTypeSettings)element).ContentType;
        }
    }
}
