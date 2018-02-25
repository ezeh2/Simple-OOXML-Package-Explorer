namespace PackageExplorer.Model
{
    using System;
    using System.IO.Packaging;

    class ExternalDocumentPart : DocumentPart
    {
        public override string Uri
        {
            get { return InnerRelationship.TargetUri.ToString(); }
        }

        public override string Name
        {
            get { return InnerRelationship.TargetUri.ToString(); }
        }

        public ExternalDocumentPart(Document owner, PackageRelationship relationship)
            : base(owner, relationship)
        {
        }
    }
}
