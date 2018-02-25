namespace PackageExplorer.Configuration
{
    using System;
    using System.Configuration;

    class PackageContentTypeSettings : ConfigurationElement
    {
        [ConfigurationProperty("contentType", IsKey=true, IsRequired=true)]
        public string ContentType
        {
            get { return (string)this["contentType"]; }
            set { this["contentType"] = value; }
        }

        public PackageContentTypeSettings()
        {

        }

        public PackageContentTypeSettings(string contentType)
        {
            ContentType = contentType;
        }
    }
}
