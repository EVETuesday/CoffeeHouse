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
using static CoffeeHouse.ClassHelper.CartClass;
using CoffeeHouse.Windows.ManagerWindows;
using CoffeeHouse.Windows.DirectorWindows;
using CoffeeHouse.Windows.ClientWindows;

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
                btnChangeProduct.Visibility = Visibility.Collapsed;
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
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
            defaultManagerWindow.Show();
            Close();
        }

        private void btnChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            ChangeStuffWindow changeStuffWindow = new ChangeStuffWindow();
            changeStuffWindow.Show();
            Close();
        }

        private void btnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.Show();
            Close();
        }
        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            bool seek = true;
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            DataBase.Stuff selectedProduct = button.DataContext as DataBase.Stuff;

            if (selectedProduct != null)
            {
                for (int i = 0; i < stuffsCart.Count; i++)
                {
                    if (stuffsCart[i]== selectedProduct)
                    {
                        stuffsCart[i].Quantity++;
                        seek= false;
                    }
                }
                if (seek)
                {
                    selectedProduct.Quantity = 1;
                    stuffsCart.Add(selectedProduct);
                }                
            }
        }
    }
}
