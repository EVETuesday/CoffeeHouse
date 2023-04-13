using CoffeeHouse.Windows.ManagerWindows;
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
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows.DirectorWondows
{
    /// <summary>
    /// Логика взаимодействия для EmploeeListWindow.xaml
    /// </summary>
    public partial class EmploeeListWindow : Window
    {
        public EmploeeListWindow()
        {
            InitializeComponent();
            GetEmploeeList();
        }
        void GetEmploeeList()
        {
            LvEmployeeList.ItemsSource = Context.Emploee.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
            defaultManagerWindow.Show();
            Close();
        }
    }
}
