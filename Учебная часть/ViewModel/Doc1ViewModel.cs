using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учебная_часть.DB;
using Учебная_часть.Models;
using Учебная_часть.Tools;
using Учебная_часть.View;

namespace Учебная_часть.ViewModel
{
    internal class Doc1ViewModel : BaseViewModel
    {
        MainViewModel mainViewModel;
        Teacher app;
        public DisGroupTeacher DTeacher { get; set; }
        private List<DisGroupTeacher> disGroupTeachers;
        public List<DisGroupTeacher> DisGroupTeacher
        {
            get => disGroupTeachers;
            set
            {
                disGroupTeachers = value;
                SignalChanged();
            }
        }

        public List<Teacher> Teacher { get; set; }


        public Doc1ViewModel(MainViewModel mainViewModel, Teacher id)
        {
            this.mainViewModel = mainViewModel;
            this.app = id;

            this.DTeacher = new DisGroupTeacher
            {
                Teacher = id.TeacherSurname
            };

            DisGroupTeacher = user30Context.GetInstance().DisGroupTeachers.Where(s => s.TeacherId == app.TeacherId).ToList();

        }
    }
}
