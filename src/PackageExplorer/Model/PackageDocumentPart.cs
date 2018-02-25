namespace PackageExplorer.Model
{
    using System;
    using System.IO.Packaging;

    class PackageDocumentPart : InternalDocumentPart
    {
        Package _package = null;

        Package InnerPackage
        {
            get
            {
                if (_package == null)
                {
                    _package = Package.Open(GetStream());
                }
                return _package;
            }
        }

        public PackageDocumentPart(Document owner, PackageRelationship relationship)
            : base(owner, relationship)
        {
            
        }

        protected override DocumentPartCollection CreateDocumentParts()
        {
            DocumentPartCollection parts = base.CreateDocumentParts();
            parts.AddRange(Owner.DocumentPartFactory.CreateDocumentParts(InnerPackage));
            return parts;
        }
    }
}
