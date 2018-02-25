namespace PackageExplorer.Configuration
{
    using System;
    using System.Configuration;

    class PartViewerSettings : ConfigurationElement
    {
        [ConfigurationProperty("contentTypes", IsRequired = true)]
        public string ContentTypes
        {
            get { return (string)this["contentTypes"]; }
            set { this["contentType"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        public PartViewerSettings()
        {

        }

        public PartViewerSettings(string name)
        {
            Name = name;
        }
    }
}
