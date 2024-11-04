using api_pi_2.Data;
using api_pi_2.Models;
using api_pi_2.DTOs;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace api_pi_2.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        public static EditProduct editProduct;
        public EditProduct(Product product)
        {
            InitializeComponent();

            editProduct = this;

            this.DataContext = product;

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

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            editProduct.Visibility = Visibility.Hidden;
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
        private bool IsDecimalValid(string decimalValue)
        {
            if (string.IsNullOrEmpty(decimalValue))
                return false;
            return decimal.TryParse(decimalValue, out _);
        }
        private async void bEdit_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            if (!IsNameProductValid(tbName.Text))
                isValid = false;

            if (!IsDecimalValid(tbCost.Text))
                isValid = false;

            if (cbType.SelectedValue == null)
                isValid = false;

            if (cbSupplier.SelectedValue == null)
                isValid = false;

            if (cbManufacturer.SelectedValue == null)
                isValid = false;

            if (!IsDigitValid(tbQuantity.Text))
                isValid = false;

            if (!string.IsNullOrEmpty(tbCurrentDiscount.Text) && !IsDigitValid(tbCurrentDiscount.Text))
                isValid = false;

            if (!string.IsNullOrEmpty(tbMaxDiscount.Text) && !IsDigitValid(tbMaxDiscount.Text))
                isValid = false;

            if (string.IsNullOrEmpty(tbStatus.Text))
                isValid = false;

            if (!string.IsNullOrEmpty(tbImage.Text) && !IsImagePathValid(tbImage.Text))
                isValid = false;

            if (!isValid)
            {
                MessageBox.Show("Неверный формат данных");
                return;
            }

            ProductDTO updateProduct = new ProductDTO
            {
                ProductArticleNumber = tbArticle.Text,
                Name = tbName.Text,
                Measure = "шт.",
                Cost = decimal.Parse(tbCost.Text),
                Description = string.IsNullOrWhiteSpace(tbDescription.Text) ? null : tbDescription.Text,
                ProductTypeId = (int)cbType.SelectedValue,
                Photo = string.IsNullOrWhiteSpace(tbImage.Text) ? null : tbImage.Text,
                SupplierId = (int)cbSupplier.SelectedValue,
                ProductMaxDiscount = int.TryParse(tbMaxDiscount.Text, out int maxDiscount) ? maxDiscount : 0,
                CurrentDiscount = int.TryParse(tbCurrentDiscount.Text, out int currentDiscount) ? currentDiscount : 0,
                ManufacturerId = (int)cbManufacturer.SelectedValue,
                QuantityInStock = int.Parse(tbQuantity.Text),
                Status = tbStatus.Text
            };

            var res = await Api.EditProduct(tbArticle.Text, updateProduct);
            if (res == true)
            {
                MessageBox.Show("Информация о товаре обновлена.");
                AdminWindow.adminWindow.LoadProducts();
                editProduct.Visibility = Visibility.Hidden;
            }
        }

        private async void bDelete_Click(object sender, RoutedEventArgs e)
        {
            var res = await Api.DeleteProduct(tbArticle.Text);
            if (res == true)
            {
                MessageBox.Show("Товар удален.");
                AdminWindow.adminWindow.LoadProducts();
                editProduct.Visibility = Visibility.Hidden;
            }
        }
    }
}
