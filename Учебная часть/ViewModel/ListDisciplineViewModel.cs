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
using System.IO;
using Aspose.Cells;

namespace Учебная_часть.ViewModel
{
    internal class ListDisciplineViewModel :BaseViewModel
    {
        private List<Discipline> disciplines;

        private DisGroupTeacher disGroupTeacher;

        private Page currentPage;
        public Discipline SelectedDiscipline { get; set; }
        public ViewCommand AddDiscipline { get; set; }
        public ViewCommand EditDiscipline { get; set; }
        public ViewCommand RemoveDiscipline { get; set; }
        public List<Discipline> Discipline
        {
            get => disciplines;
            set
            {
                disciplines = value;
                SignalChanged();
            }
        }

        public DisGroupTeacher DisGroupTeacher
        {
            get=> disGroupTeacher;
            set
            {
                disGroupTeacher = value;
                SignalChanged();
            }
        }

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                SignalChanged();

            }
        }
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
        }
    }
}
