using CoffeeHouse.ClassHelper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Pages.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        string tbWord;
        Random rnd = new Random();
        public AddClientPage()
        {
            InitializeComponent();
            CbGender.SelectedIndex = 0;
            CbGender.ItemsSource=Context.Gender.ToList();
            CbGender.DisplayMemberPath = "Gender1";
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) || string.IsNullOrEmpty(TbPassword.Text) || string.IsNullOrEmpty(TbName.Text) || string.IsNullOrEmpty(TbPasswordAgain.Text) || string.IsNullOrEmpty(TbPhone.Text)
                || TbLogin.Text == "Login" || TbName.Text == "Name" || TbPassword.Text == "Password" || TbPasswordAgain.Text == "PasswordAgain" || TbPhone.Text == "89000000000")
            {
                MessageBox.Show("Все поля с * должны быть заполненными");
                return;
            }
            if (TbPassword.Text!=TbPasswordAgain.Text)
            {
                MessageBox.Show("Пароли должны совпадать");
                return;
            }

            var OneGuest = EFClass.Context.Guest.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
            if (OneGuest != null)
            {
                MessageBox.Show("Логин занят");
                return;
            }

            DataBase.Guest guest = new DataBase.Guest();
            guest.Login = TbLogin.Text;
            guest.Name = TbName.Text;
            guest.Password = TbPassword.Text;
            guest.IDGender = (CbGender.SelectedItem as DataBase.Gender).IDGender;
            if (!string.IsNullOrEmpty(TbEmail.Text))
            {

                guest.Email = TbEmail.Text;
            }
            if (!string.IsNullOrEmpty(DpBirthday.SelectedDate.Value.ToString()))
            {
                guest.Birthday = DpBirthday.SelectedDate.Value;
            }
            guest.IDLevelDiscount = 1;
            guest.Score = 0;
            guest.Phone= TbPhone.Text;
            guest.DiscountCode = rnd.Next(100000, 999999).ToString();
            Context.Guest.Add(guest);
            Context.SaveChanges();
            MessageBox.Show("Вы зарегестрированны");

        }

        private void TbGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox a = sender as TextBox;
            tbWord= a.Text;
            if ( a.Text== "Login" || a.Text == "Name" || a.Text == "Password" || a.Text == "PasswordAgain" || a.Text == "89000000000" || a.Text == "Email@Gmail.com")
            {
                a.Text = "";
            }
        }

        private void TbLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox a = sender as TextBox;
            if (a.Text == "")
            {
                a.Text = tbWord;
            }
        }

        private void BtnToAuth_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
//