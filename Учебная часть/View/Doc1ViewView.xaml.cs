using System;
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
    /// Логика взаимодействия для Doc1ViewView.xaml
    /// </summary>
    public partial class Doc1ViewView : Page
    {
        public Teacher teacher;
        public Doc1ViewView(MainViewModel mainViewModel, Teacher app)
        {
            InitializeComponent();
            DataContext = new Doc1ViewViewModel(mainViewModel, app);

            this.teacher = app;
            text.Text = teacher.TeacherId.ToString();
        }
    }
}
