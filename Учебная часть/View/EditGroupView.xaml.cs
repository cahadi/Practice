﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Учебная_часть.Models;
using Учебная_часть.ViewModel;

namespace Учебная_часть.View
{
    /// <summary>
    /// Логика взаимодействия для EditGroupView.xaml
    /// </summary>
    public partial class EditGroupView : Page
    {
        public EditGroupView(Group edit, MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = new EditGroupViewModel(edit, mainViewModel);
        }
    }
}
