using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                
                Group = user30Context.GetInstance().Groups.ToList();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
            }
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
