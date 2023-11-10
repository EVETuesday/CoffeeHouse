using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
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
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows.DirectorWindows
{
    /// <summary>
    /// Логика взаимодействия для ChangeEmployeeWindow.xaml
    /// </summary>
    public partial class ChangeEmployeeWindow : Window
    {
        Emploee emploee1;
        Random rnd = new Random();
        string tbWord;
        public ChangeEmployeeWindow(Emploee emploee)
        {
            InitializeComponent();

            CbGender.ItemsSource = Context.Gender.ToList();
            CbGender.DisplayMemberPath = "Gender1";
            CbPost.ItemsSource = Context.Post.ToList();
            CbPost.DisplayMemberPath = "Title";

            TbName.Text = emploee.FullName;
            TbLogin.Text = emploee.Login;
            TbPassword.Text = emploee.Password;
            TbPhone.Text = emploee.Phone;
            TbEmail.Text = emploee.Email;
            DpBirthday.SelectedDate = emploee.Birthday;
            CbGender.SelectedItem = emploee.Gender;
            CbPost.SelectedItem = emploee.Post;

            emploee1 = emploee;
        }
        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) || string.IsNullOrEmpty(TbPassword.Text) || string.IsNullOrEmpty(TbName.Text) || string.IsNullOrEmpty(TbPhone.Text)
                || TbLogin.Text == "Login" || TbName.Text == "Name" || TbPassword.Text == "Password" || TbPhone.Text == "89000000000")
            {
                MessageBox.Show("Все поля с * должны быть заполненными");
                return;
            }
            emploee1.FullName = TbName.Text;
            emploee1.IDGender = (CbGender.SelectedItem as DataBase.Gender).IDGender;
            emploee1.IDPost = (CbPost.SelectedItem as DataBase.Post).IdPost;
            emploee1.Login = TbLogin.Text;
            emploee1.Password = TbPassword.Text;
            if (!string.IsNullOrEmpty(TbEmail.Text))
            {

                emploee1.Email = TbEmail.Text;
            }
            try
            {
                if (!string.IsNullOrEmpty(DpBirthday.SelectedDate.Value.ToString()))
                {
                    emploee1.Birthday = DpBirthday.SelectedDate.Value;
                }
            }
            catch
            {
                MessageBox.Show("Все поля с * должны быть заполненными");
                return;
            }
            emploee1.Phone = TbPhone.Text;
            EFClass.Context.SaveChanges();
            MessageBox.Show("Сотрудник изменён");

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