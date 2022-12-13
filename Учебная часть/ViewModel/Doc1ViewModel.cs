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
    internal class Doc1ViewModel : BaseViewModel
    {
        MainViewModel mainViewModel;

        public List<Teacher> Teachers { get; set; }
        public Doc1ViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            var db = user30Context.GetInstance();
            Teachers = db.Teachers.ToList();
        }
    }
}
