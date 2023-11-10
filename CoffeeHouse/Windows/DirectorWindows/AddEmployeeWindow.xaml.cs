using CoffeeHouse.ClassHelper;
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

namespace CoffeeHouse.Windows.DirectorWondows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        Random rnd = new Random();
        string tbWord;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            CbGender.SelectedIndex = 0;
            CbGender.ItemsSource = EFClass.Context.Gender.ToList();
            CbGender.DisplayMemberPath = "Gender1";

            CbPost.SelectedIndex = 0;
            CbPost.ItemsSource= EFClass.Context.Post.ToList();
            CbPost.DisplayMemberPath = "Title";
        }
        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) || string.IsNullOrEmpty(TbPassword.Text) || string.IsNullOrEmpty(TbName.Text) || string.IsNullOrEmpty(TbPasswordAgain.Text) || string.IsNullOrEmpty(TbPhone.Text)
                || TbLogin.Text == "Login" || TbName.Text == "Name" || TbPassword.Text == "Password" || TbPasswordAgain.Text == "PasswordAgain" || TbPhone.Text == "89000000000")
            {
                MessageBox.Show("Все поля с * должны быть заполненными");
                return;
            }
            if (TbPassword.Text != TbPasswordAgain.Text)
            {
                MessageBox.Show("Пароли должны совпадать");
                return;
            }

            var OneClient = EFClass.Context.Emploee.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
            if (OneClient != null)
            {
                MessageBox.Show("Логин занят");
                return;
            }

            DataBase.Emploee emploee = new DataBase.Emploee();
            emploee.FullName = TbName.Text;
            emploee.IDGender = (CbGender.SelectedItem as DataBase.Gender).IDGender;
            emploee.IDPost = (CbPost.SelectedItem as DataBase.Post).IdPost;
            emploee.Login=TbLogin.Text;
            emploee.Password=TbPassword.Text;
            if (!string.IsNullOrEmpty(TbEmail.Text))
            {

                emploee.Email = TbEmail.Text;
            }
            try
            {
                if (!string.IsNullOrEmpty(DpBirthday.SelectedDate.Value.ToString()))
                {
                    emploee.Birthday = DpBirthday.SelectedDate.Value;
                }
            }
            catch
            {
                MessageBox.Show("Все поля с * должны быть заполненными");
                return;
            }
            emploee.Phone = TbPhone.Text;
            emploee.PersonalCode = rnd.Next(100000, 999999).ToString();
            EFClass.Context.Emploee.Add(emploee);
            EFClass.Context.SaveChanges();
            MessageBox.Show("Сотрудник добавлен");

        }
        private void TbGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox a = sender as TextBox;
            tbWord = a.Text;
            if (a.Text == "Login" || a.Text == "Name" || a.Text == "Password" || a.Text == "PasswordAgain" || a.Text == "89000000000" || a.Text == "Email@Gmail.com")
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EmploeeListWindow emploeeListWindow = new EmploeeListWindow();
            emploeeListWindow.Show();
            Close();
        }
    }
}
//Code by writen Kirillin MP