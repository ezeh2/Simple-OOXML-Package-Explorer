namespace PackageExplorer.Configuration
{
    using System;
    using System.Configuration;

    class PackageExplorerSection : ConfigurationSection
    {
        [ConfigurationProperty("packageTypes")]
        public PackageContentTypeSettingsCollection PackageContentTypes
        {
            get { return (PackageContentTypeSettingsCollection)this["packageTypes"]; }
        }

        [ConfigurationProperty("partViewers")]
        public PartViewerSettingsCollection PartViewers
        {
            get { return (PartViewerSettingsCollection)this["partViewers"]; }
        }

        [ConfigurationProperty("defaultViewer", IsRequired=true)]
        public string DefaultViewer
        {
            get { return (string)this["defaultViewer"]; }
            set { this["defaultViewer"] = value; }
        }
    }
}
