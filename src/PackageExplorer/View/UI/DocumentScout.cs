namespace PackageExplorer.View
{
    using System;
    using System.Windows.Forms;
    using PackageExplorer.Model;

    public partial class DocumentScout : UserControl
    {
        public DocumentScout()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((DocumentPart)_scoutTabs.SelectedTab.Tag).Hide();
            if (_scoutTabs.TabCount > 0)
            {
                ((DocumentPart)_scoutTabs.SelectedTab.Tag).Show();
            }
        }

        private void _closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = _scoutTabs.SelectedTab;
            while (_scoutTabs.TabCount > 1)
            {
                TabPage page = _scoutTabs.TabPages[0];
                if (page == selectedTab)
                {
                    page = _scoutTabs.TabPages[1];
                }
                ((DocumentPart)page.Tag).Hide();
            }
        }
    }
}
