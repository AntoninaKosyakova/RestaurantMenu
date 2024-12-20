using RestaurantMenu.Models;
using System.Windows;

namespace RestaurantMenu
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();

            // Bind the orders list to the UI
            // Each order is displayed with an Order ID, Items summary, and Total Price.
            DataContext = Manager.PlacedOrders.Select((order, index) => new
            {
                // Generate a readable Order ID (index + 1)
                OrderId = index + 1,

                // Create a summary of items with their quantities for the order
                ItemsSummary = string.Join(", ", order.OrderItems.Select(item => $"{item.MenuItem.Name} x{item.Quantity}")),

                // Display the total price for the order
                TotalPrice = order.TotalPrice
            }).ToList();
        }

        /// <summary>
        /// Handles the Click event for the Close button.
        /// Closes the Orders window.
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window when the button is clicked
        }

    }
}
