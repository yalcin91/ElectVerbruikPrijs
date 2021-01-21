using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLayer.Model
{
    public class Observable : INotifyPropertyChanged
    {
        #region For WPF interface INotifyProperyChanged
        // Deze code kan altijd in een class gecopieerd worden
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
