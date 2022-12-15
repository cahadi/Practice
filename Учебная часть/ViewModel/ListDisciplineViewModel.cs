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

        //public Discipline SelectedDiscipline { get; set; }
        //public ViewCommand DisciplineExcel { get; set; }
        //public string fileName = "";
        //public string FileName
        //{
        //    get => fileName;
        //    set
        //    {
        //        fileName = value;
        //        SignalChanged();
        //    }
        //}
        //private List<DisGroupTeacher> disGroupTeachers;
        //public List<DisGroupTeacher> DisGroupTeacher
        //{
        //    get => disGroupTeachers;
        //    set
        //    {
        //        disGroupTeachers = value;
        //        SignalChanged();
        //    }
        //}

        //DisGroupTeacher app;
        public ListDisciplineViewModel(MainViewModel mainViewModel)
        {
            var db = user30Context.GetInstance();
            Discipline = db.Disciplines.ToList();
            //try
            //{
            //    DisGroupTeacher = db.DisGroupTeachers.ToList();
                
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка");
            //}

            //DisciplineExcel = new ViewCommand(() =>
            //{

            //    //if (SelectedDiscipline == null)
            //    //{
            //    //    MessageBox.Show("Для отправления формы необходимо выбрать дисциплину");
            //    //    return;
            //    //}
            //    //mainViewModel.CurrentPage = new Doc3View(mainViewModel, SelectedDiscipline);
            //    string path = $@"C:\Users\{Environment.UserName}\Desktop\{FileName}.xlsx";
            //    bool fileExist = File.Exists(path);

            //    Workbook wb;
            //    if (fileExist)
            //    {
            //        wb = new Workbook(path);
            //        Worksheet worksheet = wb.Worksheets.Add($"");
            //        Cells cells = worksheet.Cells;
            //        Aspose.Cells.Cell cell = cells["B6"];
            //        cell.PutValue("Индекс");
            //        cell = cells["C6"];
            //        cell.PutValue("Наименование дисциплин");


            //        int i =21;
            //        foreach (var a in DisGroupTeacher)
            //        {
            //            cell = cells[$"B{i}"];
            //            cell.PutValue($"{a.Discipline.DisciplineIndex}");
            //            cell = cells[$"C{i}"];
            //            cell.PutValue($"{a.Discipline.DisciplineName}");
            //            i++;
            //        }
            //        wb.Save(path, SaveFormat.Xlsx);
            //        MessageBox.Show("Отправлено");
            //    }
            //    else
            //    {
            //        File.Create(path).Close();
            //        MessageBox.Show("Файл создан. Нажмите ещё раз для отправления");
            //    }
            //});
        }
    }
}
