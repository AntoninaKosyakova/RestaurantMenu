using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantMenu
{
    public class Order
    {
        // Private field for storing order items
        private List<OrderItem> orderItems;

        /// <summary>
        /// Initializes a new instance of the Order class with an empty list of order items.
        /// </summary>
        public Order()
        {
            orderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Gets the collection of order items.
        /// </summary>
        public List<OrderItem> OrderItems
        {
            get { return orderItems; }
        }

        /// <summary>
        /// Gets the total price of all items in the order, calculated by summing the TotalCost of each OrderItem.
        /// </summary>
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in orderItems)
                {
                    total += item.TotalCost;
                }
                return total;
            }
        }

        /// <summary>
        /// Adds an item to the order, or increases the quantity if the item already exists.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        /// <param name="quantity">The quantity of the item to add.</param>
        public void AddItem(MenuItem item, int quantity)
        {
            if (item == null)
            {
                MessageBox.Show("Item cannot be null...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                //return;
            }

            OrderItem existingItem = FindExistingItem(item);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                orderItems.Add(new OrderItem(item, quantity));
            }
        }

        /// <summary>
        /// Finds an existing order item for a given menu item.
        /// </summary>
        /// <param name="item">The menu item to search for.</param>
        /// <returns>The existing OrderItem if found, otherwise null.</returns>
        private OrderItem FindExistingItem(MenuItem item)
        {
            foreach (OrderItem orderItem in orderItems)
            {
                if (orderItem.MenuItem == item)
                {
                    return orderItem;
                }
            }
            return null;
        }


        /// <summary>
        /// Clears all items from the order.
        /// </summary>
        public void ClearOrder()
        {
            orderItems.Clear();
        }

        
    }


}
