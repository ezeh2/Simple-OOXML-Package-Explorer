namespace PackageExplorer.View
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using PackageExplorer.Model;
    using System.Diagnostics;

    class ExplorerTreeView : TreeView
    {
        bool _displayRelations = false;

        public bool DisplayRelations
        {
            get { return _displayRelations; }
            set 
            {
                if (value != _displayRelations)
                {
                    _displayRelations = value;
                    // Skip root node
                    foreach (TreeNode node in Nodes)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            UpdateNodeText(childNode);
                        }
                    }
                    OnDisplayRelationsChanged(EventArgs.Empty);
                }                
            }
        }

        public void SetSelectedPart(DocumentPart part)
        {

        }

        public void SetDocument(Document document)
        {
            TreeNode rootNode = new TreeNode();
            rootNode.Tag = document;
            rootNode.Text = Path.GetFileName(document.Filename);
            foreach (DocumentPart part in document.DocumentParts)
            {
                rootNode.Nodes.Add(CreatePartNode(part));
            }
            Nodes.Add(rootNode);
        }
        
        public void ClearDocument()
        {
            Nodes.Clear();
        }

        protected virtual void OnDisplayRelationsChanged(EventArgs e)
        {
            EventHandler handler = DisplayRelationsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        protected override void OnCreateControl()
        {
            Document.Events.DocumentShow += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentShow);
            Document.Events.DocumentClose += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentClose);
            DocumentPart.Events.DocumentPartShow += new EventHandler<DocumentPartEventArgs>(DocumentPartEvents_DocumentPartShow);
            base.OnCreateControl();
        }


        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                DocumentPart part = (DocumentPart)node.Tag;
               
                foreach (DocumentPart childPart in part.DocumentParts)
                {
                    node.Nodes.Add(CreatePartNode(childPart));
                }
            }
            base.OnBeforeExpand(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (SelectedNode != null && SelectedNode.Parent != null)
            {
                ((DocumentPart)SelectedNode.Tag).Show();
            }
            base.OnMouseDoubleClick(e);
        }

        TreeNode CreatePartNode(DocumentPart part)
        {
            TreeNode node = new TreeNode();
            node.Name = part.Uri;
            Debug.WriteLine(part.Uri);
            node.Tag = part;
            if (part is PackageDocumentPart)
            {
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
            }
            else
            {
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
            }
            UpdateNodeText(node);
            return node;
        }
       
        void DocumentEvents_DocumentShow(object sender, DocumentEventArgs e)
        {
            SetDocument(e.Item);
        }

        void DocumentEvents_DocumentClose(object sender, DocumentEventArgs e)
        {
            ClearDocument();
        }

        void DocumentPartEvents_DocumentPartShow(object sender, DocumentPartEventArgs e)
        {
            SetSelectedPart(e.Item);
        }

        void UpdateNodeText(TreeNode node)
        {
            DocumentPart part = (DocumentPart)node.Tag;
            if (_displayRelations)
            {
                node.Text = String.Format("{0} - {1}", part.RelationshipID, part.Name);
            }
            else
            {
                node.Text = part.Name;
            }
            foreach (TreeNode childNode in node.Nodes)
            {
                UpdateNodeText(childNode);
            }
        }

        public event EventHandler DisplayRelationsChanged;
    }
}
