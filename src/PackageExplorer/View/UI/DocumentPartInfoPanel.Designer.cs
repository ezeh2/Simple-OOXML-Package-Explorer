namespace PackageExplorer.View
{
    partial class DocumentPartInfoPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this._documentPartNameField = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._contentTypeField = new System.Windows.Forms.Label();
            this._relationshipTypeField = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "DocumentPart:";
            // 
            // _documentPartNameField
            // 
            this._documentPartNameField.AutoSize = true;
            this._documentPartNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._documentPartNameField.Location = new System.Drawing.Point(157, 4);
            this._documentPartNameField.Name = "_documentPartNameField";
            this._documentPartNameField.Size = new System.Drawing.Size(0, 26);
            this._documentPartNameField.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ContentType:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Relationship type:";
            // 
            // _contentTypeField
            // 
            this._contentTypeField.AutoSize = true;
            this._contentTypeField.Location = new System.Drawing.Point(109, 34);
            this._contentTypeField.Name = "_contentTypeField";
            this._contentTypeField.Size = new System.Drawing.Size(0, 13);
            this._contentTypeField.TabIndex = 4;
            // 
            // _relationshipTypeField
            // 
            this._relationshipTypeField.AutoSize = true;
            this._relationshipTypeField.Location = new System.Drawing.Point(112, 56);
            this._relationshipTypeField.Name = "_relationshipTypeField";
            this._relationshipTypeField.Size = new System.Drawing.Size(0, 13);
            this._relationshipTypeField.TabIndex = 5;
            // 
            // DocumentPartInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._relationshipTypeField);
            this.Controls.Add(this._contentTypeField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._documentPartNameField);
            this.Controls.Add(this.label1);
            this.Name = "DocumentPartInfoPanel";
            this.Size = new System.Drawing.Size(568, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _documentPartNameField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _contentTypeField;
        private System.Windows.Forms.Label _relationshipTypeField;
    }
}
