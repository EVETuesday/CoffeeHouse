using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
using CoffeeHouse.Windows.CommonWindows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace CoffeeHouse.Windows.DirectorWindows
{
    /// <summary>
    /// Логика взаимодействия для ChangeStuffLineWindow.xaml
    /// </summary>
    public partial class ChangeStuffLineWindow : Window
    {
        DataBase.Stuff stuffL;
        private string pathPhoto = null;
        public ChangeStuffLineWindow(DataBase.Stuff stuff)
        {
            
            InitializeComponent();
            stuffL = stuff;
            TbNameProduct.Text = stuffL.Title;
            TbPrice.Text = stuffL.Price.ToString();
            TbExpiration.Text = stuffL.ExpirationDate.ToString();
            try
            {
                MemoryStream stream = new MemoryStream(stuffL.Image);
                ImgProduct.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            catch
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"\Resourses\Images\JpgFormat\bio_no_image.jpg", UriKind.Relative);
                bi3.EndInit();
                ImgProduct.Source = bi3;
            }
            CMBTypeProduct.ItemsSource = ClassHelper.EFClass.Context.Category.ToList();
            CMBTypeProduct.DisplayMemberPath = "Title";
            CMBTypeProduct.SelectedItem = stuffL.Category;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow productListWindow = new ProductListWindow();
            productListWindow.Show();
            Close();
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            stuffL.Title = TbNameProduct.Text;
            try
            {
                stuffL.Price = Convert.ToDecimal(TbPrice.Text);
            }
            catch
            {
                MessageBox.Show("Цена указана не верно");
                return;
            }
            stuffL.IDCategory = (CMBTypeProduct.SelectedItem as Category).IDCategory;
            if (pathPhoto != null)
            {
                stuffL.Image = File.ReadAllBytes(pathPhoto);
            }
            else
            {
                stuffL.Image = null;
            }

            try
            {
                stuffL.ExpirationDate = Convert.ToInt32(TbExpiration.Text);
            }
            catch
            {
                if (string.IsNullOrEmpty(TbExpiration.Text))
                {
                    stuffL.ExpirationDate = null;
                }
                else
                {
                    MessageBox.Show("Дата указана не верно");
                    return;
                }
            }

            if (TbExpiration.Text == "")
            {
                stuffL.ExpirationDate = null;
            }
            stuffL.Count = 0;
            if (string.IsNullOrEmpty(TbNameProduct.Text) || string.IsNullOrEmpty(TbPrice.Text))
            {
                MessageBox.Show("Все поля с * должны быть заполнены");
                return;
            }

            EFClass.Context.SaveChanges();
            MessageBox.Show("Продукт изменён");
        }
    }
}
