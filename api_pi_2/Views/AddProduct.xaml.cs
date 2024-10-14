using api_pi_2.Data;
using api_pi_2.DTOs;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace api_pi_2.Views
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public static AddProduct addProduct;
        public AddProduct()
        {
            InitializeComponent();

            addProduct = this;

            LoadProductTypes();
            LoadSuppliers();
            LoadManufacturers();
        }

        private async void LoadProductTypes()
        {
            var productTypes = await Api.GetProducttypes();
            cbType.ItemsSource = productTypes;
            cbType.DisplayMemberPath = "Name";
            cbType.SelectedValuePath = "ProductTypeId";
        }
        private async void LoadSuppliers()
        {
            var suppliers = await Api.GetSuppliers();
            cbSupplier.ItemsSource = suppliers;
            cbSupplier.DisplayMemberPath = "Name";
            cbSupplier.SelectedValuePath = "SupplierId";
        }
        private async void LoadManufacturers()
        {
            var manufacturers = await Api.GetManufacturers();
            cbManufacturer.ItemsSource = manufacturers;
            cbManufacturer.DisplayMemberPath = "Name";
            cbManufacturer.SelectedValuePath = "ManufacturerId";
        }

        static bool IsValidArticleFormat(string article)
        {
            string pattern = @"^[A-Z]\d{3}[A-Z]\d$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(article);
        }
        private bool IsNameProductValid(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            if (name.Any(char.IsDigit))
                return false;
            if (name.Length > 255)
                return false;
            return true;
        }
        private bool IsImagePathValid(string path)
        {
            if (!File.Exists(path))
                return false;
            string[] validExtensions = [".jpg", ".jpeg", ".png"];
            string fileExtension = System.IO.Path.GetExtension(path).ToLower();
            return validExtensions.Contains(fileExtension);
        }
        private bool IsDigitValid(string digit)
        {
            if (string.IsNullOrEmpty(digit))
                return false;
            if (!int.TryParse(digit, out int result))
                return false;
            return true;
        }
        private async void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidArticleFormat(tbArticle.Text) && IsNameProductValid(tbName.Text) && IsDigitValid(tbCost.Text) && cbType.SelectedValuePath != null && cbSupplier.SelectedValuePath != null && cbManufacturer.SelectedValuePath != null && IsDigitValid(tbQuantity.Text))
            {
                if ((tbImage.Text != null && IsImagePathValid(tbImage.Text)) || tbImage.Text == string.Empty)
                {
                    ProductDTO newProduct = new ProductDTO
                    {
                        ProductArticleNumber = tbArticle.Text,
                        Name = tbName.Text,
                        Measure = "шт.",
                        Cost = decimal.TryParse(tbCost.Text, out decimal cost) ? cost : 0,
                        Description = string.IsNullOrWhiteSpace(tbDescription.Text) ? null : tbDescription.Text,
                        ProductTypeId = (int)cbType.SelectedValue,
                        Photo = string.IsNullOrWhiteSpace(tbImage.Text) ? null : tbImage.Text,
                        SupplierId = (int)cbSupplier.SelectedValue,
                        ProductMaxDiscount = null,
                        CurrentDiscount = null,
                        ManufacturerId = (int)cbManufacturer.SelectedValue,
                        QuantityInStock = int.TryParse(tbQuantity.Text, out int quantity) ? quantity : 0,
                        Status = "В наличии"
                    };

                    var res = await Api.AddProduct(newProduct);
                    if (res != null)
                    {
                        MessageBox.Show("Товар добавлен.");
                        AdminWindow.adminWindow.LoadProducts();
                        addProduct.Visibility = Visibility.Hidden;
                    }
                }
                else { MessageBox.Show("Неверный путь к файлу изображения."); }
            }
            else { MessageBox.Show("Неверный формат данных"); }
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            addProduct.Visibility = Visibility.Hidden;
        }
    }
}
