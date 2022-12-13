using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Учебная_часть.Tools;
using Учебная_часть.View;

namespace Учебная_часть.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private Page currentPage;

        public Page CurrentPage 
        { 
            get => currentPage;
            set 
            { 
                currentPage = value;
                SignalChanged();
            }
        }
        public ViewCommand Welcome { get; set; }
        public ViewCommand List_Disciplines { get; set; }
        public ViewCommand List_Teachers { get ; set; }
        public ViewCommand List_Groups { get; set; }
        public MainViewModel()
        {
            CurrentPage = new WelcomePage();

            Welcome = new ViewCommand(() =>
            {
                CurrentPage = new WelcomePage();
            });
            List_Disciplines = new ViewCommand(()=>
            {
                CurrentPage = new ListDisciplinesView(this);
            });
            List_Teachers = new ViewCommand(() =>
            {
                CurrentPage = new ListTeachersView(this);
            });
            List_Groups = new ViewCommand(() =>
            {
                CurrentPage = new ListGroupsView(this);
            });
        }
    }
}
