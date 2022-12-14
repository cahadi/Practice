using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Учебная_часть.DB;
using Учебная_часть.Models;
using Учебная_часть.Tools;
using Учебная_часть.View;

namespace Учебная_часть.ViewModel
{
    internal class EditTeacherViewModel : BaseViewModel
    {
        private readonly MainViewModel mainViewModel;
        Teacher teacher;
        public Teacher EditTeacher { get; set; }
        public ViewCommand BackToList { get; set; }
        public ViewCommand SaveTea { get; set; }
        public EditTeacherViewModel(Teacher edit, MainViewModel mainViewModel)
        {
            this.teacher = edit;
            this.mainViewModel = mainViewModel;

            var db = user30Context.GetInstance();

            this.EditTeacher = new Teacher
            {
                TeacherSurname = edit.TeacherSurname,
                TeacherName = edit.TeacherName,
                TeacherPatronymic = edit.TeacherPatronymic
            };

            BackToList = new ViewCommand(() =>
            {
                mainViewModel.CurrentPage = new ListTeachersView(mainViewModel);
            });

            SaveTea = new ViewCommand(() =>
            {
                try
                {
                    if (EditTeacher.TeacherSurname == null && EditTeacher.TeacherName == null)
                    {
                        MessageBox.Show("Вы не ввели данные");
                    }
                    else
                    {
                        user30Context.GetInstance().Entry<Teacher>(teacher).CurrentValues.SetValues(EditTeacher);
                        user30Context.GetInstance().SaveChanges();
                        //SignalChanged();
                        BackToList.Execute(null);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла ошибка");
                }
            });
        }
    }
}
