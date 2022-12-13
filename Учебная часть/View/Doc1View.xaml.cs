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
using Учебная_часть.ViewModel;

namespace Учебная_часть.View
{
    /// <summary>
    /// Логика взаимодействия для Doc1View.xaml
    /// </summary>
    public partial class Doc1View : Page
    {
        public Doc1View(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = new Doc1ViewModel(mainViewModel);
        }
    }
}
