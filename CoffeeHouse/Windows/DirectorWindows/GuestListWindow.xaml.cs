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
    /// Логика взаимодействия для GuestListWindow.xaml
    /// </summary>
    public partial class GuestListWindow : Window
    {
        public GuestListWindow()
        {
            InitializeComponent();
            GetGuests();
        }
        void GetGuests()
        {
            LvGuestList.ItemsSource = Context.Guest.ToList();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
            defaultManagerWindow.Show();
            Close();
        }
    }
}
//Code by writen Kirillin MP