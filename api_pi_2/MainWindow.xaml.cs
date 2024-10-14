using api_pi_2.Data;
using api_pi_2.Models;
using api_pi_2.Views;
using System.Windows;

namespace api_pi_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;
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
            tbLogin.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }

        private async void bEnter_Click(object sender, RoutedEventArgs e)
        {
            var res = await Api.Auth(login: tbLogin.Text, password: pbPassword.Password);
            if (res is User)
            {
                App.currentUser = res;
                MessageBox.Show(res.Name.ToString());
                ProductsScreen productsScreen = new ProductsScreen();
                mainWindow.Close();
                productsScreen.Show();
            }
            else { MessageBox.Show("Пользователь не найден."); }
        }

        private void bReg_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Registration());
        }
    }
}