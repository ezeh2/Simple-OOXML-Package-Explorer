namespace PackageExplorer.View
{
    partial class DocumentScout
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._documentScoutMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._scoutTabs = new PackageExplorer.View.ScoutTabs();
            this._documentScoutMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _documentScoutMenu
            // 
            this._documentScoutMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._closeToolStripMenuItem,
            this._closeAllButThisToolStripMenuItem});
            this._documentScoutMenu.Name = "_documentScoutMenu";
            this._documentScoutMenu.Size = new System.Drawing.Size(170, 48);
            // 
            // _closeToolStripMenuItem
            // 
            this._closeToolStripMenuItem.Name = "_closeToolStripMenuItem";
            this._closeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this._closeToolStripMenuItem.Text = "&Close";
            this._closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // _closeAllButThisToolStripMenuItem
            // 
            this._closeAllButThisToolStripMenuItem.Name = "_closeAllButThisToolStripMenuItem";
            this._closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this._closeAllButThisToolStripMenuItem.Text = "Close &All  But This";
            this._closeAllButThisToolStripMenuItem.Click += new System.EventHandler(this._closeAllButThisToolStripMenuItem_Click);
            // 
            // _scoutTabs
            // 
            this._scoutTabs.ContextMenuStrip = this._documentScoutMenu;
            this._scoutTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scoutTabs.Location = new System.Drawing.Point(0, 0);
            this._scoutTabs.Name = "_scoutTabs";
            this._scoutTabs.SelectedIndex = 0;
            this._scoutTabs.Size = new System.Drawing.Size(150, 150);
            this._scoutTabs.TabIndex = 0;
            // 
            // DocumentScout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._scoutTabs);
            this.Name = "DocumentScout";
            this._documentScoutMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ScoutTabs _scoutTabs;
        private System.Windows.Forms.ContextMenuStrip _documentScoutMenu;
        private System.Windows.Forms.ToolStripMenuItem _closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _closeAllButThisToolStripMenuItem;
    }
}
