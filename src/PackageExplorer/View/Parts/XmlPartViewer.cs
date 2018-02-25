namespace PackageExplorer.View
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using PackageExplorer.Model;

    class XmlPartViewer : DocumentPartViewer
    {
        WebBrowser _browser = null;
        string _tempFilename = null;

        public XmlPartViewer()
        {
            _browser = new WebBrowser();
            _browser.Dock = DockStyle.Fill;
            Controls.Add(_browser);
        }

        public override void SetDocumentPart(DocumentPart documentPart)
        {
            DeleteTempFile();
            if (documentPart is InternalDocumentPart)
            {
                _tempFilename = Path.Combine(Path.GetTempPath(), Path.GetFileName(documentPart.Uri));
                using (Stream stream = ((InternalDocumentPart)documentPart).GetStream())
                {
                    using (FileStream fileStream = new FileStream(_tempFilename, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, 1024);
                        while (bytesRead > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                            bytesRead = stream.Read(buffer, 0, 1024);
                        }
                    }
                    _browser.Navigate(_tempFilename);
                }
            }
            else if (documentPart is ExternalDocumentPart)
            {
                _browser.Navigate(documentPart.Uri);
            }
        }

        void DeleteTempFile()
        {
            if (String.IsNullOrEmpty(_tempFilename) == false && File.Exists(_tempFilename))
            {
                File.Delete(_tempFilename);
            }
        }

        protected override void Dispose(bool disposing)
        {
            DeleteTempFile();
            base.Dispose(disposing);
        }
    }
}
