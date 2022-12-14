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
        
        public ViewCommand RemoveGroup { get; set; }

        public ListGroupViewModel(MainViewModel mainViewModel)
        {
            Group = user30Context.GetInstance().Groups.ToList();

            RemoveGroup = new ViewCommand(() =>
            {
                if (SelectedGroup == null)
                {
                    MessageBox.Show("Выберите группу для удаления");
                }
                else
                {
                    try
                    {
                        user30Context.GetInstance().Groups.Remove(SelectedGroup);
                        user30Context.GetInstance().SaveChanges();
                        SignalChanged();
                        MessageBox.Show("Выбранная группа удалена");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            });
        }

    }
}
