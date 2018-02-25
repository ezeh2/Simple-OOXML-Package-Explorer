namespace PackageExplorer.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ICSharpCode.SharpZipLib.GZip;
    using PackageExplorer.Model;
    using System.IO;

    class ZipImagePartViewer : ImagePartViewer
    {
        protected override Stream CreateImageStream(InternalDocumentPart documentPart)
        {
            return new GZipInputStream(documentPart.GetStream());
        }
    }
}
