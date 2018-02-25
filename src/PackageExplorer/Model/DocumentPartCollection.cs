namespace PackageExplorer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    class DocumentPartCollection : BindingList<DocumentPart>
    {
        public void AddRange(IEnumerable<DocumentPart> range)
        {
            foreach (DocumentPart part in range)
            {
                Add(part);
            }            
        }
    }
}
