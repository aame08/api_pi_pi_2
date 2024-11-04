using api_pi_2.Data;
using api_pi_2.DTOs;
using api_pi_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace api_pi_2.Views
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public static Account account;
        public Account(User user)
        {
            InitializeComponent();

            account = this;

            this.DataContext = user;
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            account.Visibility = Visibility.Hidden;
        }

        private void toggleShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (toggleShowPassword.IsChecked == true)
            {
                pbPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Collapsed;
                pbPassword.Password = tbPassword.Text;
                toggleShowPassword.Content = "👁";
            }
            else
            {
                pbPassword.Visibility = Visibility.Collapsed;
                tbPassword.Visibility = Visibility.Visible;
                tbPassword.Text = pbPassword.Password;
                toggleShowPassword.Content = "👁️‍🗨️";
            }
        }

        private bool IsValidInitials(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            if (str.Any(char.IsDigit))
                return false;
            if (str.Length > 50)
                return false;
            var regex = new Regex(@"^[А-ЯЁ][а-яё]+$");
            return regex.IsMatch(str);
        }
        public bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            if (password.Length > 30)
                return false;

            return true;
        }
        private async void bEdit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInitials(tbSurname.Text) && IsValidInitials(tbName.Text) && IsValidInitials(tbPatronymic.Text) && IsPasswordValid(pbPassword.Password))
            {
                UserDTO updateUser = new UserDTO
                {
                    Surname = tbSurname.Text,
                    Name = tbName.Text,
                    Patronymic = tbPatronymic.Text,
                    Login = tbLogin.Text,
                    Password = pbPassword.Password,
                };

                var res = await Api.EditAccount(App.currentUser.UserId, updateUser);
                if (res == true)
                {
                    MessageBox.Show("Информация о пользователе обновлена.");
                }
                else { MessageBox.Show("Ошибка изменения. Попробуйте другой логин."); }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }
    }
}
