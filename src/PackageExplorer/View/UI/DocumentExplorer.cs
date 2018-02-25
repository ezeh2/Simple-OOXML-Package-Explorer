namespace PackageExplorer.View
{
    using System;
    using System.Windows.Forms;

    public partial class DocumentExplorer : UserControl
    {
        public DocumentExplorer()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            documentPartView1.DisplayRelations = !toolStripButton1.Checked;
        }

        private void documentPartView1_DisplayRelationsChanged(object sender, EventArgs e)
        {
            toolStripButton1.Checked = documentPartView1.DisplayRelations;
        }
    }
}
