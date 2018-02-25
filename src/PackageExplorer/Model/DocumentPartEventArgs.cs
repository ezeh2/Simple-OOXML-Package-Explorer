namespace PackageExplorer.Model
{
    using System;

    class DocumentPartEventArgs : ObjectEventArgs<DocumentPart>
    {
        public DocumentPartEventArgs()
        {
        }

        public DocumentPartEventArgs(DocumentPart item) : base(item)
        {
        }
    }
}
