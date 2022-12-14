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
    public class ListTeacherViewModel : BaseViewModel
    {
        private List<Teacher> teacher;

        public List<Teacher> Teacher
        {
            get => teacher;
            set
            {
                teacher = value;
                SignalChanged();
            }
        }

        public Teacher SelectedTeacher { get; set; }

        public ViewCommand AddTeacher { get; set; }
        public ViewCommand EditTeacher { get; set; }
        public ViewCommand RemoveTeacher { get; set; }

        public ListTeacherViewModel(MainViewModel mainViewModel)
        {
            Teacher = user30Context.GetInstance().Teachers.ToList();

            AddTeacher = new ViewCommand(() =>
            {
                mainViewModel.CurrentPage = new EditTeacherView(new Teacher(), mainViewModel);
            });
            EditTeacher = new ViewCommand(() =>
            {
                if (SelectedTeacher == null)
                {
                    MessageBox.Show("Выберите преводавателя");
                }
                else
                    mainViewModel.CurrentPage = new EditTeacherView(SelectedTeacher, mainViewModel);
            });
            RemoveTeacher = new ViewCommand(() =>
            {
                if (SelectedTeacher == null)
                    MessageBox.Show("Для удаления необхлдимо выбрать преводавателя");


            });
        }
    }
}
