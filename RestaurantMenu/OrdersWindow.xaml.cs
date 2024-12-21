using RestaurantMenu.Models;
using System.Linq;
using System.Windows;

namespace RestaurantMenu
{
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();

            // Bind the _placedOrders list from MenuManager to the UI
            OrdersList.ItemsSource = MenuManager.PlacedOrders.Select((order, index) => new OrderViewModel
            {
                OrderInfo = $"Order {index + 1} : Total: {order.TotalPrice:C}",
                OrderReference = order
            }).ToList();
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            // Get the OrderViewModel associated with the clicked button
            var button = sender as FrameworkElement;
            var orderToDelete = button?.DataContext as OrderViewModel;

            if (orderToDelete != null)
            {
                // Remove the order from the _placedOrders list in MenuManager
                MenuManager.PlacedOrders.Remove(orderToDelete.OrderReference);

                // Refresh the displayed orders
                OrdersList.ItemsSource = MenuManager.PlacedOrders.Select((order, index) => new OrderViewModel
                {
                    OrderInfo = $"Order {index + 1} : Total: {order.TotalPrice:C}",
                    OrderReference = order
                }).ToList();
            }
        }
    }

    public class OrderViewModel
    {
        public string OrderInfo { get; set; }
        public Order OrderReference { get; set; }
    }
}
