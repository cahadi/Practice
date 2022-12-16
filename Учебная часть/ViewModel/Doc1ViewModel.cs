using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учебная_часть.DB;
using Учебная_часть.Models;
using Учебная_часть.Tools;
using Учебная_часть.View;
using IronXL;
using Aspose.Cells;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Учебная_часть.ViewModel
{
    internal class Doc1ViewModel : BaseViewModel
    {
        MainViewModel mainViewModel;

        DisGroupTeacher app;

        public string fileName = "";

        private List<DisGroupTeacher> disGroupTeachers;
        public ViewCommand Enter { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<DisGroupTeacher> DisGroupTeacher
        {
            get => disGroupTeachers;
            set
            {
                disGroupTeachers = value;
                SignalChanged();
            }
        }

        public string FileName 
        { 
            get => fileName;
            set
            {
                fileName = value;
                SignalChanged();
            }
        }
        public Doc1ViewModel(MainViewModel mainViewModel, Teacher ap)
        {
            this.mainViewModel = mainViewModel;

            var db = user30Context.GetInstance();
            app = db.DisGroupTeachers.FirstOrDefault(s=> s.TeacherId == ap.TeacherId);
            //app.Teacher = db.Teachers.FirstOrDefault(s=> s.TeacherId == ap.TeacherId);
            Teachers = db.Teachers.ToList();

            try
            {
                DisGroupTeacher = user30Context.GetInstance().DisGroupTeachers.Where(s => s.TeacherId == app.TeacherId).ToList();
                foreach(var ds in DisGroupTeacher)
                {
                    ds.Teacher = Teachers.FirstOrDefault(s=> s.TeacherId == ds.TeacherId);  //B3  A3 - ФИО
                    ds.Discipline = db.Disciplines.FirstOrDefault(s=> s.DisciplineId == ds.DisciplineId);  //B7 - B...  B4 - Дисциплина
                    ds.Group = db.Groups.FirstOrDefault(s => s.GroupId == ds.GroupId);  //C7 - C...  C4 - Группа
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

            Workbook wb;

            Enter = new ViewCommand(() =>
            {
                string path = $@"C:\Users\{Environment.UserName}\Desktop\{FileName}.xlsx";
                bool fileExist = File.Exists(path);
                if (fileExist)
                {
                    wb = new Workbook(path);
                    Worksheet worksheet = wb.Worksheets.Add(ap.TeacherSurname);
                    Cells cells = worksheet.Cells;
                    Aspose.Cells.Cell cell = cells["B3"];
                    cell.PutValue($"{ap.TeacherSurname} {ap.TeacherName} {ap.TeacherPatronymic}");
                    cell = cells["A3"];
                    cell.PutValue("ФИО");
                    cell = cells["B6"];
                    cell.PutValue("Дисциплина"); 
                    cell = cells["C6"];
                    cell.PutValue("Группа");

                    int i = 7;
                    foreach (var a in DisGroupTeacher)
                    {
                        cell = cells[$"B{i}"];
                        cell.PutValue($"{a.Discipline.DisciplineName}");
                        cell = cells[$"C{i}"];
                        cell.PutValue($"{a.Group.GroupNumber}");
                        i++;
                    }
                    wb.Save(path, SaveFormat.Xlsx);
                    MessageBox.Show("Отправлено");
                }
                else
                {
                    File.Create(path).Close();
                    MessageBox.Show("Файл создан. Нажмите ещё раз для отправления");
                }
                //"C:\Users\Student\Desktop"
            });
        }
    }
}
