using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
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
using static CoffeeHouse.ClassHelper.AuthUserClass;
using CoffeeHouse.Windows.ManagerWindows;

namespace CoffeeHouse.Windows.CommonWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
            if (authEmploee.IDPost!=1)
            {
                btnAddProduct.Visibility = Visibility.Collapsed;
            }            
            GetProduct();
        }
        private void GetProduct()
        {
            List<Stuff> stuffList = new List<Stuff>();
            stuffList = EFClass.Context.Stuff.ToList();
            LvProductList.ItemsSource= stuffList;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            FunctionProduct functionProduct = new FunctionProduct();
            functionProduct.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
            defaultManagerWindow.Show();
            Close();
        }
    }
}
