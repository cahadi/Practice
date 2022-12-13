using System.Collections.Generic;
using Учебная_часть.Models;
using Учебная_часть.Tools;
using Учебная_часть.DB;
using System.Linq;
using System.Windows;
using System;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using Учебная_часть.View;

namespace Учебная_часть.ViewModel
{
    internal class ListDisciplineViewModel :BaseViewModel
    {
        private List<Discipline> disciplines;

        public List<Discipline> Discipline
        {
            get => disciplines;
            set
            {
                disciplines = value;
                SignalChanged();
            }
        }

        private DisGroupTeacher disGroupTeacher;

        public DisGroupTeacher DisGroupTeacher
        {
            get=> disGroupTeacher;
            set
            {
                disGroupTeacher = value;
                SignalChanged();
            }
        }

        private string search = "";

        public string Search
        {
            get => search;
            set
            {
                search = value;
                DoSearch();
            }
        }

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

        public Discipline SelectedDiscipline { get; set; }

        public ViewCommand AddDiscipline { get; set; }
        public ViewCommand EditDiscipline { get; set; }
        public ViewCommand RemoveDiscipline { get; set; }

        public ListDisciplineViewModel(MainViewModel mainViewModel)
        {
            Discipline = user30Context.GetInstance().Disciplines.ToList();

            AddDiscipline = new ViewCommand(() =>
            {
                mainViewModel.CurrentPage = new EditDisciplineView(new Discipline(), mainViewModel);
            });
            EditDiscipline = new ViewCommand(() =>
            {
                if(SelectedDiscipline == null)
                {
                    MessageBox.Show("Выберите дисциплину для редактирования");
                    return;
                }
                mainViewModel.CurrentPage = new EditDisciplineView(SelectedDiscipline, mainViewModel);
            });
            RemoveDiscipline = new ViewCommand(() =>
            {
                if(SelectedDiscipline == null)
                {
                    MessageBox.Show("Выберите дисциплину для удаления");
                }
                else
                {
                    try
                    { 
                        user30Context.GetInstance().Disciplines.Remove(SelectedDiscipline);
                        user30Context.GetInstance().SaveChanges();
                        DoSearch();
                        MessageBox.Show("Выбранная дисциплина удалена");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            });
        }

        private void DoSearch()
        {
            try
            {
                var count = user30Context.GetInstance().Disciplines.Count();

                var search = user30Context.GetInstance().Disciplines
                    .Include("DisciplineIndex")
                    .Include("DisciplineName")
                    .Include("TypeDiscipline").Where(
                    s => s.DisciplineIndex.Contains(Search) ||
                    s.DisciplineName.Contains(Search) ||
                    s.TypeDisciplines.TypeDisciplines.Contains(Search));

                var dis = search.ToList();


                if(dis.Count == 0)
                {
                    MessageBox.Show("По данному запросу ничего не найдено");
                }
                Discipline = dis;
            }
            catch
            {
            }
        }
    }
}
