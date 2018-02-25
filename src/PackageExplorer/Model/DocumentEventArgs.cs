namespace PackageExplorer.Model
{
    using System;

    class DocumentEventArgs : ObjectEventArgs<Document>
    {
        public DocumentEventArgs()
        {
        }

        public DocumentEventArgs(Document document)
            : base(document)
        {
        }
    }
}
