using CoffeeHouse.Pages.CommonPages;
using CoffeeHouse.Pages.DirectorPages;
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
using System.Windows.Shapes;

namespace CoffeeHouse.Windows.Director
{
    /// <summary>
    /// Логика взаимодействия для DefaultDirectorWindow.xaml
    /// </summary>
    public partial class DefaultDirectorWindow : Window
    {
        public DefaultDirectorWindow()
        {
            InitializeComponent();
            DirectorFrame.Content = new AddProductPage();
        }
    }
}
