using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Учебная_часть.DB;
using Учебная_часть.Models;
using Учебная_часть.Tools;

namespace Учебная_часть.ViewModel
{
    internal class Doc2ViewModel :BaseViewModel
    {
        MainViewModel mainViewModel;

        DisGroupTeacher app;

        public string fileName = "";

        private List<DisGroupTeacher> disGroupTeachers;
        public List<Group> Groups { get; set; }
        public ViewCommand Enter { get; set; }
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

        public Doc2ViewModel(MainViewModel mainViewModel, Group ap)
        {
            this.mainViewModel = mainViewModel;

            var db = user30Context.GetInstance();
            app = db.DisGroupTeachers.FirstOrDefault(s => s.GroupId == ap.GroupId);
            //app.Teacher = db.Teachers.FirstOrDefault(s=> s.TeacherId == ap.TeacherId);
            Groups = db.Groups.ToList();

            try
            {
                DisGroupTeacher = user30Context.GetInstance().DisGroupTeachers.Where(s => s.GroupId == app.GroupId).ToList();
                foreach (var ds in DisGroupTeacher)
                {
                    ds.Teacher = db.Teachers.FirstOrDefault(s => s.TeacherId == ds.TeacherId); 
                    ds.Discipline = db.Disciplines.FirstOrDefault(s => s.DisciplineId == ds.DisciplineId); 
                    ds.Group = Groups.FirstOrDefault(s => s.GroupId == ds.GroupId); 
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
                    Worksheet worksheet = wb.Worksheets.Add($"{ap.GroupNumber}");
                    Cells cells = worksheet.Cells;
                    Aspose.Cells.Cell cell = cells["V4"];
                    cell.PutValue($"{ap.GroupCountStudent}");
                    cell = cells["U4"];
                    cell.PutValue("Кол-во студентов");

                    cell = cells["A8"];
                    cell.PutValue("Индекс");
                    cell = cells["B8"];
                    cell.PutValue("Дисциплина");
                    cell = cells["AB8"];
                    cell.PutValue("Преподаватель");

                    int i = 9;
                    foreach (var a in DisGroupTeacher)
                    {
                        cell = cells[$"A{i}"];
                        cell.PutValue($"{a.Discipline.DisciplineIndex}");
                        cell = cells[$"B{i}"];
                        cell.PutValue($"{a.Discipline.DisciplineName}");
                        cell = cells[$"AB{i}"];
                        cell.PutValue($"{a.Teacher.TeacherSurname} {a.Teacher.TeacherName} {a.Teacher.TeacherPatronymic}");
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
