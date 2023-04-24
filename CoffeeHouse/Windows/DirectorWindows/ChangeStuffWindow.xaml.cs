using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
using CoffeeHouse.Windows.CommonWindows;
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

namespace CoffeeHouse.Windows.DirectorWindows
{
    /// <summary>
    /// Логика взаимодействия для ChangeStuffWindow.xaml
    /// </summary>
    public partial class ChangeStuffWindow : Window
    {
        public ChangeStuffWindow()
        {
            InitializeComponent();
            GetProduct();
        }
        private void GetProduct()
        {
            List<Stuff> stuffList = new List<Stuff>();
            stuffList = EFClass.Context.Stuff.ToList();
            LvProductList.ItemsSource = stuffList;
        }

        private void btnChangeToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DataBase.Stuff stuff = button.DataContext as DataBase.Stuff;
            if (stuff!=null)
            {
                ChangeStuffLineWindow changeStuffLineWindow = new ChangeStuffLineWindow(stuff);
                changeStuffLineWindow.Show();
                Close();
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow productListWindow = new ProductListWindow();
            productListWindow.Show();
            Close();
        }
    }
}
