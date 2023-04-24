using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
using Microsoft.Win32;
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
using System.IO;
using CoffeeHouse.Windows.CommonWindows;

namespace CoffeeHouse.Windows.DirectorWindows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private string pathPhoto = null;
        public AddProductWindow()
        {
            InitializeComponent();
            CMBTypeProduct.ItemsSource = EFClass.Context.Category.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "Title";
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Stuff product = new Stuff();
            product.Title = TbNameProduct.Text;
            try
            {
                product.Price = Convert.ToDecimal(TbPrice.Text);
            }
            catch
            {
                MessageBox.Show("Цена указана не верно");
                return;
            }
            product.IDCategory = (CMBTypeProduct.SelectedItem as Category).IDCategory;
            if (pathPhoto != null)
            {
                product.Image = File.ReadAllBytes(pathPhoto);
            }
            else
            {
                product.Image = null;
            }

            try
            {
                product.ExpirationDate = Convert.ToInt32(TbExpiration.Text);
            }
            catch
            {
                if (string.IsNullOrEmpty(TbExpiration.Text))
                {
                    product.ExpirationDate = null;
                }
                else
                {
                    MessageBox.Show("Дата указана не верно");
                    return;
                }
            }

            if (TbExpiration.Text == "")
            {
                product.ExpirationDate = null;
            }
            product.Count = 0;
            if (string.IsNullOrEmpty(TbNameProduct.Text) || string.IsNullOrEmpty(TbPrice.Text))
            {
                MessageBox.Show("Все поля с * должны быть заполнены");
                return;
            }

            EFClass.Context.Stuff.Add(product);
            EFClass.Context.SaveChanges();
            MessageBox.Show("Продукт добавлен");
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    pathPhoto = openFileDialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Изоображение имеет неверный формат");
                }

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