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

        public ViewCommand RemoveTeacher { get; set; }

        public ListTeacherViewModel(MainViewModel mainViewModel)
        {
            try
            {
                Teacher = user30Context.GetInstance().Teachers.ToList();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
            }

            RemoveTeacher = new ViewCommand(() =>
            {
                if (SelectedTeacher == null)
                    MessageBox.Show("Для удаления необходимо выбрать преподавателя");
                else
                {
                    try
                    {
                        user30Context.GetInstance().Teachers.Remove(SelectedTeacher);
                        user30Context.GetInstance().SaveChanges();
                        MessageBox.Show("Выбранный преподаватель удалён");
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
