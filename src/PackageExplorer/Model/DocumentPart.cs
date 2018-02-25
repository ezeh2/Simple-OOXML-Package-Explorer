namespace PackageExplorer.Model
{
    using System;
    using System.IO.Packaging;

    abstract class DocumentPart : Object
    {
        Document _owner = null;
        PackageRelationship _relationship = null;
        DocumentPartCollection _documentParts = null;

        public DocumentPartCollection DocumentParts
        {
            get
            {
                if (_documentParts == null)
                {
                    _documentParts = CreateDocumentParts();
                }
                return _documentParts;
            }
        }

        public virtual string Name
        {
            get
            {
                return _relationship.Id;
            }
        }

        public string RelationshipType
        {
            get { return _relationship.RelationshipType; }
        }

        public string RelationshipID
        {
            get { return _relationship.Id; }
        }

        public virtual string ContentType
        {
            get { return _relationship.RelationshipType; }
        }

        public abstract string Uri { get;}

        public Document Owner
        {
            get { return _owner; }
        }

        protected PackageRelationship InnerRelationship
        {
            get { return _relationship; }
        }

        protected DocumentPart(Document owner, PackageRelationship relationship)
        {
            _owner = owner;
            _relationship = relationship;
        }

        public void Show()
        {
            OnDocumentPartShow(new DocumentPartEventArgs(this));
        }

        public void Hide()
        {
            OnDocumentPartHide(new DocumentPartEventArgs(this));
        }

        protected virtual DocumentPartCollection CreateDocumentParts()
        {
            return new DocumentPartCollection();
        }

        protected virtual void OnDocumentPartShow(DocumentPartEventArgs e)
        {
            EventHandler<DocumentPartEventArgs> handler = DocumentPartShow;
            if (handler != null)
            {
                handler(this, e);
            }
            Events.RaiseDocumentPartShow(this, e);
        }

        protected virtual void OnDocumentPartHide(DocumentPartEventArgs e)
        {
            EventHandler<DocumentPartEventArgs> handler = DocumentPartHide;
            if (handler != null)
            {
                handler(this, e);
            }
            Events.RaiseDocumentPartHide(this, e);
        }

        public event EventHandler<DocumentPartEventArgs> DocumentPartHide;
        public event EventHandler<DocumentPartEventArgs> DocumentPartShow;

        public static class Events
        {
            internal static void RaiseDocumentPartShow(DocumentPart sender, DocumentPartEventArgs e)
            {
                EventHandler<DocumentPartEventArgs> handler = DocumentPartShow;
                if (handler != null)
                {
                    handler(sender, e);
                }
            }

            internal static void RaiseDocumentPartHide(DocumentPart sender, DocumentPartEventArgs e)
            {
                EventHandler<DocumentPartEventArgs> handler = DocumentPartHide;
                if (handler != null)
                {
                    handler(sender, e);
                }
            }

            public static event EventHandler<DocumentPartEventArgs> DocumentPartHide;
            public static event EventHandler<DocumentPartEventArgs> DocumentPartShow;
        }
    }
}
