using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учебная_часть.DB;
using Учебная_часть.Models;
using Учебная_часть.Tools;

namespace Учебная_часть.ViewModel
{
    public class ListGroupViewModel : BaseViewModel
    {
        private List<Group> group;

        public ListGroupViewModel(MainViewModel mainViewModel)
        {
            Group = user30Context.GetInstance().Groups.ToList();
        }

        public List<Group> Group
        {
            get => group;
            set
            {
                group = value;
                SignalChanged();
            }
        }

    }
}
