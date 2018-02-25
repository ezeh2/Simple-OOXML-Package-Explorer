namespace PackageExplorer.View
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Windows.Forms;
    using PackageExplorer.Model;
    using PackageExplorer.Configuration;

    class ScoutTabs : TabControl
    {
        Dictionary<DocumentPart, TabPage> _tabPages = null;
        
        public void OpenDocumentPart(DocumentPart documentPart)
        {
            TabPage page = null;
            if (_tabPages.ContainsKey(documentPart))
            {
                page = _tabPages[documentPart];
            }
            else
            {
                page = new TabPage(documentPart.Name);
                page.Tag = documentPart;
                DocumentPartViewer viewControl = CreateViewControl(documentPart);
                viewControl.SetDocumentPart(documentPart);
                viewControl.Dock = DockStyle.Fill;
                page.Controls.Add((Control)viewControl);
                TabPages.Add(page);
                _tabPages.Add(documentPart, page);
            }
            SelectedTab = page;
        }

        public void CloseDocumentPart(DocumentPart documentPart)
        {
            if (_tabPages.ContainsKey(documentPart))
            {
                TabPages.Remove(_tabPages[documentPart]);
                _tabPages.Remove(documentPart);
            }            
        }

        public void CloseDocument()
        {           
            TabPages.Clear();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < TabPages.Count; i++)
                {
                    if (GetTabRect(i).Contains(e.Location) && SelectedIndex != i)
                    {
                        SelectedIndex = i;
                    }
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnCreateControl()
        {            
            _tabPages = new Dictionary<DocumentPart, TabPage>();
            Document.Events.DocumentClose += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentClose);
            DocumentPart.Events.DocumentPartShow += new EventHandler<DocumentPartEventArgs>(DocumentPartEvents_DocumentPartShow);
            DocumentPart.Events.DocumentPartHide += new EventHandler<DocumentPartEventArgs>(DocumentPartEvents_DocumentPartHide);
            base.OnCreateControl();
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            if (base.DesignMode == false)
            {
                if (e.TabPage != null)
                {
                    if (e.Action == TabControlAction.Selecting)
                    {
                        ((DocumentPart)e.TabPage.Tag).Show();
                    }
                }
            }
            base.OnSelecting(e);
        }

        void DocumentEvents_DocumentClose(object sender, DocumentEventArgs e)
        {
            CloseDocument();
        }

        void DocumentPartEvents_DocumentPartShow(object sender, DocumentPartEventArgs e)
        {
            OpenDocumentPart(e.Item);
        }

        void DocumentPartEvents_DocumentPartHide(object sender, DocumentPartEventArgs e)
        {
            CloseDocumentPart(e.Item);
        }

        DocumentPartViewer CreateViewControl(DocumentPart part)
        {
            PackageExplorerSection config = (PackageExplorerSection)ConfigurationManager.GetSection("packageExplorer");
            PartViewerSettings settings = null;
            foreach (PartViewerSettings partViewer in config.PartViewers)
            {
                foreach (string contentType in partViewer.ContentTypes.Split('|'))
                {
                    if (String.Equals(part.ContentType, contentType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        settings = partViewer;
                    }
                }
            }
            if (settings == null)
            {
                settings = config.PartViewers[config.DefaultViewer];
            }
            return (DocumentPartViewer)Activator.CreateInstance(Type.GetType(settings.Type));
        }
    }
}
