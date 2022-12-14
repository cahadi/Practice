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
    internal class EditDisciplineViewModel :BaseViewModel
    {
        private readonly MainViewModel mainViewModel;

        public Discipline EditDiscipline { get; set; }
        public ViewCommand SaveDis { get; set; }
        public ViewCommand BackToList { get; set; }
        public List<TypeDiscipline> TypeDisciplines { get; set; }

        Discipline original;
        public EditDisciplineViewModel(Discipline edit, MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            original = edit;

            var db = user30Context.GetInstance();
            TypeDisciplines = db.TypeDisciplines.ToList();
            this.EditDiscipline = new Discipline
            {
                DisciplineIndex = edit.DisciplineIndex,
                DisciplineName = edit.DisciplineName,
                TypeDisciplines = edit.TypeDisciplines
            };

            BackToList = new ViewCommand(() =>
            {
                mainViewModel.CurrentPage = new ListDisciplinesView(mainViewModel);
            });

            SaveDis = new ViewCommand(() =>
            {
                try
                {
                    if (EditDiscipline.DisciplineName == null || EditDiscipline.TypeDisciplines == null)
                    {
                        MessageBox.Show("Вы не ввели данные");
                        return;
                    }
                    user30Context.GetInstance().Entry<Discipline>(original).CurrentValues.SetValues(EditDiscipline);
                    user30Context.GetInstance().SaveChanges();
                    SignalChanged(nameof(EditDiscipline));
                    BackToList.Execute(null);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                    return ;
                }
            });
        }
    }
}
