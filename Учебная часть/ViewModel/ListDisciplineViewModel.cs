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
                        SignalChanged();
                        MessageBox.Show("Выбранная дисциплина удалена");
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
