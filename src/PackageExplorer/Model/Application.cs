namespace PackageExplorer.Model
{
    using System;
    using System.Windows.Forms;
    using PackageExplorer.Model;
    using WinApp = System.Windows.Forms.Application;

    static class Application
    {
        static Document _activeDocument = null;

        public static Document ActiveDocument
        {
            get { return _activeDocument; }
        }

        static Application()
        {
            Document.Events.DocumentShow += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentShow);
            Document.Events.DocumentClose += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentClose);
        }

        public static void Exit()
        {
            if (_activeDocument != null)
            {
                _activeDocument.Close();
            }
            WinApp.Exit();
        }

        static void DocumentEvents_DocumentClose(object sender, DocumentEventArgs e)
        {
            if (e.Item == _activeDocument)
            {
                _activeDocument = null;
            }
        }

        static void DocumentEvents_DocumentShow(object sender, DocumentEventArgs e)
        {
            _activeDocument = e.Item;
        }
    }
}