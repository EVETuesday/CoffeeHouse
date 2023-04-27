using CoffeeHouse.ClassHelper;
using CoffeeHouse.Windows.CommonWindows;
using CoffeeHouse.Windows.DirectorWindows;
using CoffeeHouse.Windows.DirectorWondows;
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
using static CoffeeHouse.ClassHelper.AuthUserClass;

namespace CoffeeHouse.Windows.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для DefaultManagerWindow.xaml
    /// </summary>
    public partial class DefaultManagerWindow : Window
    {
        public DefaultManagerWindow()
        {
            InitializeComponent();
            tbHeaderUser.Content = authEmploee.FullName + " | " + authEmploee.Post.Title;
            if (authEmploee.IDPost==2)
            {
                btnEmployeeList.IsEnabled = false;
                btnGuestList.IsEnabled = false;
                btnOrders.IsEnabled = false;
            }
        }

        private void btnProductList_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow productListWindow = new ProductListWindow();
            productListWindow.Show();
            Close();
        }

        private void btnEmployeeList_Click(object sender, RoutedEventArgs e)
        {
            EmploeeListWindow emploeeListWindow = new EmploeeListWindow();
            emploeeListWindow.Show();
            Close();
        }

        private void btnGuestList_Click(object sender, RoutedEventArgs e)
        {
            GuestListWindow guestListWindow = new GuestListWindow();
            guestListWindow.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            Close();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            CheckOrderWindow checkOrderWindow = new CheckOrderWindow();
            checkOrderWindow.Show();
            Close();
        }
    }
}
