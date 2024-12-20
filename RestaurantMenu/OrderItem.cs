using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantMenu
{
    public class OrderItem
    {
        // Private fields for the data
        private MenuItem menuItem;
        private int quantity;

        /// <summary>
        /// Initializes a new instance of the OrderItem class with the specified menu item and quantity.
        /// </summary>
        /// <param name="menuItem">The food item from the menu.</param>
        /// <param name="quantity">The number of times the food item is selected.</param>
        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the MenuItem for the order item.
        /// </summary>
        public MenuItem MenuItem
        {
            get { return menuItem; }
            set
            {
                if (value == null)
                {
                    MessageBox.Show("Menu Item cannot be null or empty...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;
                }
                menuItem = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity of the food item.
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 1)
                {
                    MessageBox.Show("Quantity should be at least 1....", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;
                }
                quantity = value;
            }
        }

        /// <summary>
        /// Gets the total cost of the order item, calculated by multiplying MenuItem.Price by Quantity.
        /// </summary>
        public double TotalCost
        {
            get
            {
                return MenuItem.Price * Quantity;
            }
        }

       
    }

}
