using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace RestaurantMenu
{
    

    /// <summary>
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        private List<MenuItem> _list;


        public EditItem(List<MenuItem> list)
        {
            InitializeComponent();
            _list = list;
        }

        public List<MenuItem> EditItemMethod(MenuItem item, List<MenuItem> list)
        {

            MenuItem newItemVersion = new MenuItem
            (
              EditName.Text,
              EditDescription.Text,
              ValidateAndConvertToDouble(EditPrice.Text),
              EditImagePath.Text

           );

            //assign item to the newly item created
            item = newItemVersion;
            
            return list;
        }

        /// <summary>
        /// Checks if the input string can be converted to a double.
        /// If valid, converts and returns the double value.
        /// If invalid, shows an error message and returns null.
        /// </summary>
        /// <param name="input">The string to validate and convert.</param>
        /// <returns>The converted double value, or null if invalid.</returns>
        public double ValidateAndConvertToDouble(string input)
        {
            if (double.TryParse(input, out double result))
            {
                return result;
            }
            else
            {
                MessageBox.Show("Invalid input. We will be assigning a default value of 0...", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

        private void EditImagePath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
