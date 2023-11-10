using CoffeeHouse.Windows.ManagerWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace CoffeeHouse.Windows.DirectorWindows
{
    /// <summary>
    /// Логика взаимодействия для CheckOrderWindow.xaml
    /// </summary>
    public partial class CheckOrderWindow : Window
    {
        string orderby= "Не выбрано";
        public CheckOrderWindow()
        {
            InitializeComponent();
            getOrders();
        }
        void getOrders()
        {
            dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList();
        }


        void getOrders(DatePicker dateF, DatePicker dateN)
        {
            dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().Where(i=>i.Date>=dateF.SelectedDate && i.Date<=dateN.SelectedDate);
        }
        void getOrders(string word)
        {
            if ((ClassHelper.EFClass.Context.vw_Orders.ToList().Where(j => j.Title.ToLower().Contains(word.ToLower()) || j.FullName.ToLower().Contains(word.ToLower()) || j.Name.ToLower().Contains(word.ToLower())|| j.Quantity.ToString().ToLower().Contains(word.ToLower()) || j.Cost.ToString().ToLower().Contains(word.ToLower())).ToList().FirstOrDefault())   != null)
            {
                dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().Where(i => i.Title.ToLower().Contains(word.ToLower()) || i.FullName.ToLower().Contains(word.ToLower())|| i.Name.ToLower().Contains(word.ToLower()) || i.Quantity.ToString().ToLower().Contains(word.ToLower())|| i.Cost.ToString().ToLower().Contains(word.ToLower()));
            }
            else
            {
                dgOrders.ItemsSource = null;
            }
        }
        void getOrders(string word, bool b)
        {

                switch (word)
                {
                    case "Не выбрано":

                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList();
                        orderby = "Не выбрано";

                        break;
                    case "Работник":
                        orderby = "Работник";
                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().OrderBy(i => i.FullName);
                        break;
                    case "Клиент":
                        orderby = "Клиент";
                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().OrderBy(i => i.Name);
                        break;
                    case "Время продажи":
                        orderby = "Время продажи";
                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().OrderBy(i => i.Date);
                        break;
                    case "Продукт":
                        orderby = "Продукт";
                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().OrderBy(i => i.Title);
                        break;
                    case "Количество":
                        orderby = "Количество";
                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().OrderBy(i => i.Quantity);
                        break;
                    case "Цена":
                        orderby = "Цена";
                        dgOrders.ItemsSource = ClassHelper.EFClass.Context.vw_Orders.ToList().OrderBy(i => i.Cost);
                        break;
                    default:
                        break;
                }
            
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            getOrders(tbSearch.Text);
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string a = cmbSort.SelectedValue.ToString();
            a=a.Substring(38,a.Length-38);
            getOrders(a, false);
        }

        private void btnDateSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpNext.SelectedDate.Value < dpFirst.SelectedDate.Value)
                {
                    DatePicker datePicker = new DatePicker();
                    datePicker.SelectedDate = dpNext.SelectedDate;
                    dpNext.SelectedDate = dpNext.SelectedDate;
                    dpFirst.SelectedDate = datePicker.SelectedDate;
                }

                getOrders(dpFirst, dpNext);
            }
            catch
            {
                getOrders();
            }
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