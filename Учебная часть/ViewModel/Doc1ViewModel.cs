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

        //public ViewCommand EnterExcel { get; set; }
        public ViewCommand SeeDisGroupTeacher { get; set; }

        public List<Teacher> Teachers { get; set; }
        public Teacher SelectedTeacher { get; set; }

        public Doc1ViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            var db = user30Context.GetInstance();
            Teachers = db.Teachers.ToList();

            SeeDisGroupTeacher = new ViewCommand(() =>
            {
                mainViewModel.CurrentPage = new Doc1ViewView(mainViewModel, SelectedTeacher);
            });
        }
    }
}
