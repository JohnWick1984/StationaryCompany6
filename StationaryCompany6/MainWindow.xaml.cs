using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace StationaryCompany6
{
    public partial class MainWindow : Window
    {
        private StationaryDbContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new StationaryDbContext();
            LoadProducts();
            LoadSales();
            LoadManagers();
        }

        private void LoadProducts()
        {
            productComboBox.ItemsSource = db.Products.ToList();
        }

        private void LoadManagers()
        {
            managerComboBox.ItemsSource = db.Managers.ToList();
        }

        private void LoadSales()
        {
            saleDataGrid.ItemsSource = db.Sales.ToList();
        }
        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = (Product)productComboBox.SelectedItem;
            if (selectedProduct != null)
            {
                productNameTextBox.Text = selectedProduct.Product_Name;
                productTypeTextBox.Text = selectedProduct.Product_Type;
                quantityTextBox.Text = selectedProduct.Quantity.ToString();
                costPriceTextBox.Text = selectedProduct.Cost_Price.ToString();

                
                var salesForProduct = db.Sales.Where(s => s.Product_ID == selectedProduct.Product_ID).ToList();
                saleDataGrid.ItemsSource = salesForProduct;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Changes saved successfully.");
        }

        private void ManagerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager selectedManager = (Manager)managerComboBox.SelectedItem;
            if (selectedManager != null)
            {
                firstNameTextBox.Text = selectedManager.FirstName;
                lastNameTextBox.Text = selectedManager.LastName;
            }
        }

        public class Product
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public string Product_Type { get; set; }
            public int Quantity { get; set; }
            public decimal Cost_Price { get; set; }
        }

        public class Sale
        {
            public int Sale_ID { get; set; }
            public int Product_ID { get; set; }
            public int Manager_ID { get; set; }
            public string Buyer_Company_Name { get; set; }
            public int Quantity_Sold { get; set; }
            public decimal Unit_Price { get; set; }
            public DateTime Sale_Date { get; set; }
        }

        public class Manager
        {
            public int Manager_ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class StationaryDbContext : DbContext
        {
            public StationaryDbContext() : base("Data Source=EUGENE1984; Initial Catalog=StationeryCompany; Integrated Security=True;")
            {
            }

            public DbSet<Product> Products { get; set; }
            public DbSet<Sale> Sales { get; set; }
            public DbSet<Manager> Managers { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Product>().HasKey(p => p.Product_ID);
                modelBuilder.Entity<Sale>().HasKey(s => s.Sale_ID);
                modelBuilder.Entity<Manager>().HasKey(m => m.Manager_ID);
            }
        }
    }
}