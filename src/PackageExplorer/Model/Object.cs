namespace PackageExplorer.Model
{
    using System;
    using System.ComponentModel;

    class Object : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
