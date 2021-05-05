using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertychanged(string PropName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }
    }
}
