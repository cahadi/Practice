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

        public ViewCommand RemoveDiscipline { get; set; }

        public ListDisciplineViewModel(MainViewModel mainViewModel)
        {
            try
            {
                Discipline = user30Context.GetInstance().Disciplines.ToList();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
            }
            

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
