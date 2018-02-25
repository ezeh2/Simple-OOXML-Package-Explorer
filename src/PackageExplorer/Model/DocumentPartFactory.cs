namespace PackageExplorer.Model
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.IO.Packaging;
    using PackageExplorer.Configuration;

    class DocumentPartFactory
    {
        Document _owner = null;
        List<String> _packageContentTypes = null;
 
        public DocumentPartFactory(Document owner)
        {
            _owner = owner;
            _packageContentTypes = new List<string>();
            PackageExplorerSection config = (PackageExplorerSection)ConfigurationManager.GetSection("packageExplorer");
            PackageContentTypeSettingsCollection packageTypes = config.PackageContentTypes;
            foreach (PackageContentTypeSettings packageType in packageTypes)
            {
                _packageContentTypes.Add(packageType.ContentType);
            }
        }

        public DocumentPartCollection CreateDocumentParts(Package package)
        {
            DocumentPartCollection parts = new DocumentPartCollection();
            foreach (PackageRelationship relationship in package.GetRelationships())
            {
                parts.Add(CreateDocumentPart(relationship));
            }
            return parts;
        }

        public DocumentPartCollection CreateDocumentParts(PackagePart packagePart)
        {
            DocumentPartCollection parts = new DocumentPartCollection();
            foreach (PackageRelationship relationship in packagePart.GetRelationships())
            {
                parts.Add(CreateDocumentPart(relationship));
            }
            return parts;
        }

        public DocumentPart CreateDocumentPart(PackageRelationship relationship)
        {
            DocumentPart documentPart = null;
            if (relationship.TargetMode == TargetMode.Internal)
            {
                if (IsPackageType(relationship.RelationshipType))
                {
                    documentPart = new PackageDocumentPart(_owner, relationship);
                }
                else
                {
                    documentPart = new InternalDocumentPart(_owner, relationship);
                }
            }
            else
            {
                documentPart = new ExternalDocumentPart(_owner, relationship);
            }
            return documentPart;
        }

        bool IsPackageType(string relationshipType)
        {
            System.Diagnostics.Debug.WriteLine(relationshipType);
            return _packageContentTypes.Contains(relationshipType);
        }
    }
}
