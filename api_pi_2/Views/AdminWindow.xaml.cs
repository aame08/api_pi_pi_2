using api_pi_2.Data;
using api_pi_2.Models;
using System.Windows;

namespace api_pi_2.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static AdminWindow adminWindow;
        private List<Product> allProducts = new List<Product>();
        private List<Product> currentProducts = new List<Product>();
        public AdminWindow()
        {
            InitializeComponent();

            adminWindow = this;

            LoadProducts();
        }

        public async void LoadProducts()
        {
            var res = await Api.GetProducts();
            allProducts = res;
            currentProducts = allProducts;

            DisplayProducts(allProducts);
        }
        private void DisplayProducts(List<Product> products)
        {
            dgProducts.Items.Clear();

            foreach (var product in products)
            {
                dgProducts.Items.Add(product);
            }
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            adminWindow.Close();
        }

        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var search = tbSearch.Text;
            if (!string.IsNullOrEmpty(search))
            {
                currentProducts = currentProducts.Where(p => p.Name.ToLower().Contains(search.ToLower()) || p.ProductArticleNumber.ToLower().Contains(search.ToLower())).ToList();
            }
            else { currentProducts = allProducts; }
            DisplayProducts(currentProducts);
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new AddProduct());
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)dgProducts.SelectedItem;
            EditProduct editProduct = new EditProduct(selectedProduct);
            frame.NavigationService.Navigate(editProduct, Visibility.Visible);
        }
    }
}
