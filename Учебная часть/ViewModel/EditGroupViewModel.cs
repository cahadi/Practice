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
    internal class EditGroupViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        Group group;

        public Group EditGroup { get; set; }
        public ViewCommand BackToList { get; set; }
        public ViewCommand SaveGro { get; set; }

        public EditGroupViewModel(Group edit, MainViewModel mainViewModel)
        {
            this.group = edit;
            this.mainViewModel = mainViewModel;


            var db = user30Context.GetInstance();
            this.EditGroup = new Group
            {
                GroupNumber = edit.GroupNumber,
                GroupCountStudent = edit.GroupCountStudent
            };

            BackToList = new ViewCommand(() =>
            {
                mainViewModel.CurrentPage = new ListGroupsView(mainViewModel);
            });

            SaveGro = new ViewCommand(() =>
            {
                try
                {
                    if(EditGroup.GroupCountStudent <= 0)
                    {
                        MessageBox.Show("Учащихся в группе не может быть меньше одного");
                        return;
                    }
                    user30Context.GetInstance().Entry<Group>(group).CurrentValues.SetValues(EditGroup);
                    user30Context.GetInstance().SaveChanges();
                    SignalChanged();
                    BackToList.Execute(null);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            });
        }
    }
}
