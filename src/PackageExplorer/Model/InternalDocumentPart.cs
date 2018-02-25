namespace PackageExplorer.Model
{
    using System;
    using System.IO;
    using System.IO.Packaging;

    class InternalDocumentPart : DocumentPart
    {
        PackagePart _packagePart = null;

        PackagePart InnerPackagePart
        {
            get
            {
                if (_packagePart == null)
                {
                    PackageRelationship relationship = InnerRelationship;
                    _packagePart = relationship.Package.GetPart(
                        PackUriHelper.ResolvePartUri(
                            relationship.SourceUri, relationship.TargetUri));        
                }
                return _packagePart;
            }
        }

        public override string ContentType
        {
            get { return _packagePart.ContentType; }
        }

        public override string Uri
        {
            get { return PackUriHelper.ResolvePartUri(InnerRelationship.SourceUri, InnerRelationship.TargetUri).ToString(); }
        }

        public override string Name
        {
            get { return Path.GetFileName(InnerRelationship.TargetUri.ToString()); }
        }

        public InternalDocumentPart(Document owner, PackageRelationship relationship)
            : base(owner, relationship)
        {
            }

        public Stream GetStream()
        {
            return _packagePart.GetStream();
        }

        protected override DocumentPartCollection CreateDocumentParts()
        {
            DocumentPartCollection parts = base.CreateDocumentParts();
            parts.AddRange(Owner.DocumentPartFactory.CreateDocumentParts(InnerPackagePart));
            return parts;
        }
    }
}
