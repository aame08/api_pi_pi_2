using api_pi_2.Data;
using api_pi_2.Models;
using System.Windows;

namespace api_pi_2.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsScreen.xaml
    /// </summary>
    public partial class ProductsScreen : Window
    {
        public static ProductsScreen productsScreen;
        private List<Product> allProducts = new List<Product>();
        private List<Product> currentProducts = new List<Product>();
        public ProductsScreen()
        {
            InitializeComponent();

            productsScreen = this;

            username.Content = App.currentUser.Name;
            LoadProducts();

            List<string> sorts = new List<string> { "По возрастанию цены", "По убыванию цены" };
            cbSort.ItemsSource = sorts;
            cbSort.SelectionChanged += cbSort_SelectionChanged;
        }

        private async void LoadProducts()
        {
            var res = await Api.GetProducts();
            allProducts = res;
            currentProducts = allProducts;

            DisplayProducts(allProducts);
        }
        private void DisplayProducts(List<Product> products)
        {
            lvProducts.Items.Clear();

            foreach (var product in products)
            {
                ProductUC productUC = new ProductUC(product);
                lvProducts.Items.Add(productUC);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            productsScreen.Close();
        }

        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var search = tbSearch.Text;
            if (!string.IsNullOrEmpty(search))
            {
                currentProducts = currentProducts.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            else { currentProducts = allProducts; }
            DisplayProducts(currentProducts);
        }

        private void cbSort_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedSort = cbSort.SelectedItem as string;
            if (selectedSort != null)
            {
                if (selectedSort == "По возрастанию цены") { currentProducts = currentProducts.OrderBy(p => p.Cost).ToList(); }
                else if (selectedSort == "По убыванию цены") { currentProducts = currentProducts.OrderByDescending(p => p.Cost).ToList(); }
            }

            DisplayProducts(currentProducts);
        }
    }
}
