namespace PackageExplorer.View
{
    using System;
    using System.Windows.Forms;
    using PackageExplorer.Model;

    abstract class DocumentPartViewer : Control
    {
        public abstract void SetDocumentPart(DocumentPart documentPart);
    }
}
