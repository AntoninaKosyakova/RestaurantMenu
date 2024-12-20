using RestaurantMenu.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using MenuItem = RestaurantMenu.Models.MenuItem;

namespace RestaurantMenu
{
    public partial class AddItem : Window
    {
        private List<MenuItem> targetList;

        public AddItem(List<MenuItem> list)
        {
            InitializeComponent();
            targetList = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get input values from textboxes
            string name = NameTextBox.Text.Trim();
            string description = DescriptionTextBox.Text.Trim();
            string priceText = PriceTextBox.Text.Trim();
            string imagePath = ImagePathTextBox.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("Please fill out all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(priceText, out double price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create new MenuItem
            MenuItem newItem = new MenuItem(name, description, price, imagePath);

            // Check if the list has room and add the item
            if (targetList.Count >= 2)
            {
                MessageBox.Show("List already contains the maximum of 2 items. Cannot add more.", "Max Capacity Reached", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            targetList.Add(newItem);
            MessageBox.Show($"Item '{newItem.Name}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the input fields for new entry
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
            PriceTextBox.Clear();
            ImagePathTextBox.Clear();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
