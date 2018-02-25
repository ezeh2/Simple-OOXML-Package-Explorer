namespace PackageExplorer.Model
{
    using System;
    using System.IO.Packaging;

    class Document : Object, IDisposable
    {
        DocumentPartCollection _documentParts = null;
        string _filename = null;
        Package _package = null;
        bool _disposed = false;
        DocumentPartFactory _documentFactory = null;

        internal DocumentPartFactory DocumentPartFactory
        {
            get { return _documentFactory; }
        }

        public string Filename
        {
            get { return _filename; }
        }

        public DocumentPartCollection DocumentParts
        {
            get
            {
                AssertDisposed();
                if (_documentParts == null)
                {
                    _documentParts = new DocumentPartCollection();
                    _documentParts.AddRange(DocumentPartFactory.CreateDocumentParts(InnerPackage));
                }
                return _documentParts;
            }
        }

        Package InnerPackage
        {
            get
            {
                AssertDisposed();
                if (_package == null)
                {
                    _package = Package.Open(_filename);
                }
                return _package;
            }
        }

        public Document(string filename)
        {
            _filename = filename;
            _documentFactory = new DocumentPartFactory(this);
        }

        ~Document()
        {
            Dispose(false);
        }

        public static void Open()
        {
            Events.RaiseDocumentOpen(new DocumentEventArgs());
        }

        public void Show()
        {
            OnShow(new DocumentEventArgs(this));
        }

        public void Close()
        {
            OnClose(new DocumentEventArgs(this));
            ((IDisposable)this).Dispose();
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _package.Close();
                    _package = null;
                }
                _disposed = true;
            }
        }

        protected virtual void OnShow(DocumentEventArgs e)
        {
            EventHandler<DocumentEventArgs> handler = DocumentShow;
            if (handler != null)
            {
                handler(this, e);
            }
            Events.RaiseDocumentShow(this, e);
        }

        protected virtual void OnClose(DocumentEventArgs e)
        {
            EventHandler<DocumentEventArgs> handler = DocumentClose;
            if (handler != null)
            {
                handler(this, e);
            }
            Events.RaiseDocumentClose(this, e);
        }

        void AssertDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Document");
            }
        }

        public event EventHandler<DocumentEventArgs> DocumentShow;
        public event EventHandler<DocumentEventArgs> DocumentClose;

        public static class Events
        {
            internal static void RaiseDocumentOpen(DocumentEventArgs e)
            {
                EventHandler<DocumentEventArgs> handler = DocumentOpen;
                if (handler != null)
                {
                    handler(null, e);
                }
            }

            internal static void RaiseDocumentShow(Document document, DocumentEventArgs e)
            {
                EventHandler<DocumentEventArgs> handler = DocumentShow;
                if (handler != null)
                {
                    handler(null, e);
                }
            }

            internal static void RaiseDocumentClose(Document document, DocumentEventArgs e)
            {
                EventHandler<DocumentEventArgs> handler = DocumentClose;
                if (handler != null)
                {
                    handler(null, e);
                }
            }

            public static event EventHandler<DocumentEventArgs> DocumentOpen;
            public static event EventHandler<DocumentEventArgs> DocumentShow;
            public static event EventHandler<DocumentEventArgs> DocumentClose;
        }
    }
}
