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
    /// Логика взаимодействия для Doc2View.xaml
    /// </summary>
    public partial class Doc2View : Page
    {
        public Doc2View(MainViewModel mainViewModel, Group id)
        {
            InitializeComponent();
            DataContext = new Doc2ViewModel(mainViewModel, id);
        }
    }
}
