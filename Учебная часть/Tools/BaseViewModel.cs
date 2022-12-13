using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_часть.Tools
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SignalChanged([CallerMemberName] string ooo = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ooo));
        }
    }
}
