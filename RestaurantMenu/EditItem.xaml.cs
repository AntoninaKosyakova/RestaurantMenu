using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantMenu
{
    public partial class EditItem : Window
    {
        private MenuItem _item;
        private List<MenuItem> _list;
       // private MenuPage _menuPage; // Reference to the MenuPage

        public EditItem(MenuItem item, List<MenuItem> list)
        {
            InitializeComponent();
            _item = item;
            _list = list;
            //_menuPage = menuPage;

            // Populate the input fields with the current item's data
            EditName.Text = _item.Name;
            EditDescription.Text = _item.Description;
            EditPrice.Text = _item.Price.ToString();
            EditImagePath.Text = _item.ImagePath;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateItem(); // Update the item in the list
            this.Close(); // Close the EditItem window
        }

        private void UpdateItem()
        {
            // Update the item's properties
            _item.Name = EditName.Text;
            _item.Description = EditDescription.Text;
            _item.Price = ValidateAndConvertToDouble(EditPrice.Text);
            _item.ImagePath = EditImagePath.Text;

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
            // Optional: Add validation or live update logic here
        }

        private void EditDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add validation or live update logic here
        }

        private void EditPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add validation or live update logic here
        }

        private void EditImagePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add validation or live update logic here
        }
    }
}
