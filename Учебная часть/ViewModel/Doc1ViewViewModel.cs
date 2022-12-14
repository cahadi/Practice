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
    internal class Doc1ViewViewModel : BaseViewModel
    {
        MainViewModel mainViewModel;
        Teacher app;

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


        public Doc1ViewViewModel(MainViewModel mainViewModel, Teacher app)
        {
            this.mainViewModel = mainViewModel;
            this.app = app;

            DisGroupTeacher = user30Context.GetInstance().DisGroupTeachers.ToList();

        }
    }
}
