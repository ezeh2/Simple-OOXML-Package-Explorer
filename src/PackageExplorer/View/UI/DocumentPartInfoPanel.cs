namespace PackageExplorer.View
{
    using System;
    using System.Windows.Forms;
    using PackageExplorer.Model;

    partial class DocumentPartInfoPanel : UserControl
    {
        public DocumentPartInfoPanel()
        {
            InitializeComponent();
        }

        public void SetDocumentPart(DocumentPart documentPart)
        {
            _contentTypeField.Text = documentPart.ContentType;
            _relationshipTypeField.Text = documentPart.RelationshipType;
            _documentPartNameField.Text = documentPart.Name;
        }

        public void ClearDocumentPart()
        {
            _contentTypeField.Text = "";
            _relationshipTypeField.Text = "";
            _documentPartNameField.Text = "";
        }

        protected override void OnCreateControl()
        {
            Document.Events.DocumentClose += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentClose);
            DocumentPart.Events.DocumentPartShow += new EventHandler<DocumentPartEventArgs>(DocumentPartEvents_DocumentPartShow);
            base.OnCreateControl();
        }

        void DocumentEvents_DocumentClose(object sender, DocumentEventArgs e)
        {
            ClearDocumentPart();
        }

        void DocumentPartEvents_DocumentPartShow(object sender, DocumentPartEventArgs e)
        {
            e.Item.DocumentPartHide += new EventHandler<DocumentPartEventArgs>(DocumentPartEvents_DocumentPartHide);
            SetDocumentPart(e.Item);
        }

        void DocumentPartEvents_DocumentPartHide(object sender, DocumentPartEventArgs e)
        {
            e.Item.DocumentPartHide -= new EventHandler<DocumentPartEventArgs>(DocumentPartEvents_DocumentPartHide);
            ClearDocumentPart();
        }
    }
}
