using RestaurantMenu.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MenuItem = RestaurantMenu.Models.MenuItem;

namespace RestaurantMenu
{
    public partial class EditItem : Window
    {
        private MenuItem _item;
        private List<MenuItem> _list;

        // Add EditedItem property to return the updated item
        public MenuItem EditedItem { get; private set; }

        public EditItem(MenuItem item, List<MenuItem> list)
        {
            InitializeComponent();
            _item = item;
            _list = list;

            // Populate ComboBox with valid image paths
            PopulateImagePaths();

            // Populate fields with existing item data
            EditName.Text = _item.Name;
            EditDescription.Text = _item.Description;
            EditPrice.Text = _item.Price.ToString();
            cmbImagePaths.SelectedItem = _item.ImagePath; // Set existing image path
        }

        private void PopulateImagePaths()
        {
            foreach (string path in MenuItem.ValidImagePaths)
            {
                cmbImagePaths.Items.Add(path); // Add each valid path to ComboBox
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateItem(); // Update the item in the list

            // Set the EditedItem property with the updated item
            EditedItem = _item;

            // Close the EditItem window with a success result
            DialogResult = true;
            Close();
        }

        private void UpdateItem()
        {
            // Update the item's properties
            _item.Name = EditName.Text;
            _item.Description = EditDescription.Text;
            _item.Price = ValidateAndConvertToDouble(EditPrice.Text);
            _item.ImagePath = cmbImagePaths.SelectedItem as string;

            // No need to notify MenuPage explicitly; it will refresh itself
        }

        private double ValidateAndConvertToDouble(string input)
        {
            if (double.TryParse(input, out double result))
            {
                return result;
            }
            else
            {
                MessageBox.Show("Invalid price input. Assigning a default value of 0.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        private void EditName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void EditDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void EditPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void cmbImagePaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
