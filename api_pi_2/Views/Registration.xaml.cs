using api_pi_2.Data;
using api_pi_2.DTOs;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace api_pi_2.Views
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public static Registration registration;
        public Registration()
        {
            InitializeComponent();

            registration = this;
        }

        private void toggleShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (toggleShowPassword.IsChecked == true)
            {
                pbPassword.Visibility = Visibility.Collapsed;
                tbPassword.Visibility = Visibility.Visible;
                tbPassword.Text = pbPassword.Password;
                toggleShowPassword.Content = "👁️‍🗨️";
            }
            else
            {
                pbPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Collapsed;
                pbPassword.Password = tbPassword.Text;
                toggleShowPassword.Content = "👁";
            }
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            registration.Visibility = Visibility.Hidden;
        }

        private bool IsValidInitials(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            if (str.Any(char.IsDigit))
                return false;
            if (str.Length > 50)
                return false;
            var regex = new Regex(@"^([А-ЯЁ][а-яё]+)([- ]([А-ЯЁ][а-яё]+))?$");
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
        private async void bEnter_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInitials(tbSurname.Text) && IsValidInitials(tbName.Text) && IsValidInitials(tbPatronymic.Text) && IsPasswordValid(pbPassword.Password))
            {
                UserDTO newUser = new UserDTO
                {
                    Surname = tbSurname.Text,
                    Name = tbName.Text,
                    Patronymic = tbPatronymic.Text,
                    Login = tbLogin.Text,
                    Password = pbPassword.Password,
                    Role = 1
                };

                var res = await Api.Register(newUser);
                if (res != null)
                {
                    MessageBox.Show("Вы зарегистрированы.");
                    registration.Visibility = Visibility.Hidden;
                }
                else { MessageBox.Show("Ошибка регистрации. Попробуйте другой логин."); }
            }
            else { MessageBox.Show("Неверный формат данных."); }
        }
    }
}
