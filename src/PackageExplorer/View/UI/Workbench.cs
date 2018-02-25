namespace PackageExplorer.Views
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using PackageExplorer.Model;
    using PackageExplorer.View;
    using PackApp = PackageExplorer.Model.Application;

    public partial class Workbench : Form
    {
        public Workbench()
        {
            InitializeComponent();

            DocumentExplorer explorer = new DocumentExplorer();
            explorer.Dock = DockStyle.Fill;
            _splitContainer.Panel1.Controls.Add(explorer);

            DocumentScout scout = new DocumentScout();
            scout.Dock = DockStyle.Fill;
            _splitContainer.Panel2.Controls.Add(scout);

            DocumentPartInfoPanel infoPanel = new DocumentPartInfoPanel();
            infoPanel.Dock = DockStyle.Top;
            infoPanel.Margin = new Padding(12);
            _splitContainer.Panel2.Controls.Add(infoPanel);

            Document.Events.DocumentOpen += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentOpen);
            Document.Events.DocumentShow += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentShow);
            Document.Events.DocumentClose += new EventHandler<DocumentEventArgs>(DocumentEvents_DocumentClose);
        }

        void DocumentEvents_DocumentOpen(object sender, DocumentEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Word Documents|*.docx|Word Macro-enabled Documents|*.docx|Word Templates|*.dotx|Excel Documents|*.xlsx|Excel Macro-enabled Documents|*.xlsm|Excel Templates|*.xltx|All Files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                Document document = new Document(filename);
                document.Show();
            }
        }

        void DocumentEvents_DocumentShow(object sender, DocumentEventArgs e)
        {
            // TODO: Find a better way
            AssemblyProductAttribute product = (AssemblyProductAttribute)
                Attribute.GetCustomAttribute(Assembly.GetEntryAssembly(), typeof(AssemblyProductAttribute));
            Text = String.Format("{0} - {1}", product.Product, Path.GetFileName(e.Item.Filename));
        }

        void DocumentEvents_DocumentClose(object sender, DocumentEventArgs e)
        {
            // TODO: Find a better way
            AssemblyProductAttribute product = (AssemblyProductAttribute)
                Attribute.GetCustomAttribute(Assembly.GetEntryAssembly(), typeof(AssemblyProductAttribute));
            Text = product.Product;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PackApp.ActiveDocument != null)
            {
                PackApp.ActiveDocument.Close();
            }
            Document.Open();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PackApp.ActiveDocument != null)
            {
                PackApp.ActiveDocument.Close();
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackApp.Exit();
        }
    }
}