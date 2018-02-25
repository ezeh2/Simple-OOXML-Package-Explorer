namespace PackageExplorer.View
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using PackageExplorer.Model;

    class ImagePartViewer : DocumentPartViewer
    {
        PictureBox _picture = null;

        public ImagePartViewer()
        {
            _picture = new PictureBox();
            _picture.SizeMode = PictureBoxSizeMode.AutoSize;
            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Controls.Add(_picture);
            panel.Dock = DockStyle.Fill;
            Controls.Add(panel);
        }

        public override void SetDocumentPart(DocumentPart documentPart)
        {
            InternalDocumentPart internalPart = documentPart as InternalDocumentPart;
            if (internalPart != null)
            {
                Image image = null;
                using (Stream stream = CreateImageStream(internalPart))
                {
                    image = Image.FromStream(stream);                    
                }
                _picture.Image = image;
            }
        }

        protected virtual Stream CreateImageStream(InternalDocumentPart documentPart)
        {
            return documentPart.GetStream();
        }
    }
}
