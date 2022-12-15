using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Учебная_часть.DB;
using Учебная_часть.Models;
using Учебная_часть.Tools;
using Учебная_часть.View;

namespace Учебная_часть.ViewModel
{
    public class ListGroupViewModel : BaseViewModel
    {
        private List<Group> group;

        public List<Group> Group
        {
            get => group;
            set
            {
                group = value;
                SignalChanged();
            }
        }

        public Group SelectedGroup { get; set; }
        public ViewCommand GroupExcel { get; set; }

        public ListGroupViewModel(MainViewModel mainViewModel)
        {
            Group = user30Context.GetInstance().Groups.ToList();

            GroupExcel = new ViewCommand(() =>
            {

                if (SelectedGroup == null)
                {
                    MessageBox.Show("Для отправления формы необходимо выбрать группу");
                    return;
                }
                mainViewModel.CurrentPage = new Doc2View(mainViewModel, SelectedGroup);
            });

        }

    }
}
