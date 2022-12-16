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
            var db = user30Context.GetInstance();
            Discipline = db.Disciplines.ToList();
        }
    }
}
