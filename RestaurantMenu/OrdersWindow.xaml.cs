using RestaurantMenu.Models;
using System.Windows;

namespace RestaurantMenu
{
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();

            // Populate the orders list from MenuManager.PlacedOrders
            RefreshOrdersList();
        }

        private void RefreshOrdersList()
        {
            // Clear the current list in the UI
            OrdersList.Items.Clear();

            // Add each order from MenuManager.PlacedOrders to the list
            int orderNumber = 1;
            foreach (var order in MenuManager.PlacedOrders)
            {
                // Create a simple string to represent the order
                string orderInfo = $"Order {orderNumber} : Total: {order.TotalPrice:C}";
                OrdersList.Items.Add(new { OrderInfo = orderInfo, Order = order });
                orderNumber++;
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            // Get the order to delete from the button's DataContext
            var button = sender as FrameworkElement;
            var orderToDelete = button?.DataContext as dynamic; // Using dynamic for simplicity

            if (orderToDelete != null && orderToDelete.Order != null)
            {
                // Remove the corresponding order from MenuManager.PlacedOrders
                MenuManager.PlacedOrders.Remove(orderToDelete.Order);

                // Refresh the list
                RefreshOrdersList();
            }
        }
    }
}
