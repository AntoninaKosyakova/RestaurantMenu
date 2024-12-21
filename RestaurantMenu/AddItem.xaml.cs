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

            // Populate the ComboBox with the hardcoded list of image paths
            PopulateImagePaths();
        }

        /// <summary>
        ///     Populates the ComboBox with predefined image paths.
        /// </summary>
        private void PopulateImagePaths()
        {
            cmbImagePaths.Items.Clear();
            foreach (var path in MenuItem.ValidImagePaths)
            {
                // Add each valid path to ComboBox
                cmbImagePaths.Items.Add(path);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get input values from textboxes
            string name = NameTextBox.Text.Trim();
            string description = DescriptionTextBox.Text.Trim();
            string priceText = PriceTextBox.Text.Trim();
            string imagePath = cmbImagePaths.SelectedItem as string;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrEmpty(imagePath))
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
            cmbImagePaths.SelectedIndex = -1; // Reset ComboBox selection
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBrowseFolder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbImagePaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
