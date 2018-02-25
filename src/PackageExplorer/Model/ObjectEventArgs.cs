namespace PackageExplorer.Model
{
    using System;
    using System.Collections.Generic;

    class ObjectEventArgs<T> : EventArgs where T : Object
    {
        T _item = null;

        public T Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public ObjectEventArgs()
        {

        }

        public ObjectEventArgs(T item)
        {
            _item = item;
        }
    }
}
