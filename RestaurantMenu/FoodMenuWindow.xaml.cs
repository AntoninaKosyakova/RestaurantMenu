using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RestaurantMenu
{
    /// <summary>
    /// Interaction logic for FoodMenuWindow.xaml
    /// </summary>
    public partial class FoodMenuWindow : Window
    {
        // Stores the current order being placed
        private Order currentOrder;

        /// <summary>
        /// Constructor for the FoodMenuWindow class.
        /// Initializes components and loads menu items from the Manager class.
        /// </summary>
        public FoodMenuWindow()
        {
            InitializeComponent(); // Initializes the WPF components from XAML
            currentOrder = new Order(); // Creates a new Order object to manage the current order
            PopulateMenu();  // Populate UI dynamically
        }

        /// <summary>
        /// Dynamically populate the menu sections using Manager's lists.
        /// </summary>
        private void PopulateMenu()
        {
            // Populate the panels with Manager's lists
            PopulatePanel(StartersPanel, Manager.Starters);
            PopulatePanel(MainDishesPanel, Manager.MainDishes);
            PopulatePanel(DessertsPanel, Manager.Desserts);
        }

        /// <summary>
        /// Populates a specific panel with buttons for each menu item.
        /// </summary>
        /// <param name="panel">The StackPanel to populate.</param>
        /// <param name="menuItems">The list of menu items to add to the panel.</param>
        private void PopulatePanel(StackPanel panel, List<MenuItem> menuItems)
        {
            // Clear any existing content in the panel
            panel.Children.Clear();

            // Add a button for each menu item
            foreach (MenuItem item in menuItems)
            {
                // Create a Grid for each menu item
                Grid itemGrid = new Grid();
                itemGrid.Margin = new Thickness(10);

                // Define columns for the image, name/description, and button
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                // Create the Image for the dish
                Image imgDish = new Image
                {
                    Source = new BitmapImage(new Uri(item.ImagePath, UriKind.RelativeOrAbsolute)),
                    Height = 70,
                    Width = 70,
                    Margin = new Thickness(5, 0, 10, 0),
                };

                // Create the TextBlock for the item name/description
                TextBlock dishContent = new TextBlock
                {
                    Text = item.ToString(),
                    FontSize = 12,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5, 0, 10, 0), // Add spacing between TextBlock and Button
                    Foreground = new SolidColorBrush(Colors.White)
                };

                // Create a button for the menu item
                Button button = new Button
                {
                    Content = "add", // Button label
                    Tag = item, // Store the MenuItem object in the button's Tag property
                    FontSize = 10,
                    Height = 20,
                    Width = 20
                };

                // Attach a click event handler to the button
                button.Click += AddToOrder_Click;

                // Add elements to the Grid
                itemGrid.Children.Add(imgDish);
                Grid.SetColumn(imgDish, 0);

                itemGrid.Children.Add(dishContent);
                Grid.SetColumn(dishContent, 1);

                itemGrid.Children.Add(button);
                Grid.SetColumn(button, 2);

                // Add the StackPanel to the appropriate parent panel
                panel.Children.Add(itemGrid);
            }
        }

        /// <summary>
        ///     Handles the "Add" button click event to add a menu item to the order.
        /// </summary>
        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is MenuItem menuItem)
            {
                // Add the selected menu item to the current order with a quantity of 1
                currentOrder.AddItem(menuItem, 1);

                // Refresh the order summary display to show the updated order
                UpdateOrderSummary();
            }
        }

        /// <summary>
        ///     Updates the "Your Order" section with the current list of items in the order.
        /// </summary>
        private void UpdateOrderSummary()
        {
            if (currentOrder.OrderItems.Count == 0)
            {
                // Display a placeholder message if the order is empty
                OrderSummary.Text = "No items in your order.";
                return;
            }

            // Build the order summary text
            OrderSummary.Text = string.Empty;
            foreach (OrderItem item in currentOrder.OrderItems)
            {
                OrderSummary.Text += $"{item}\n"; // Append each order item
            }
            OrderSummary.Text += $"\nTotal: {currentOrder.TotalPrice:C}"; // Display the total price
        }

        /// <summary>
        ///     Clears the current order and resets the "Your Order" section.
        /// </summary>
        private void ClearOrderButton_Click(object sender, RoutedEventArgs e)
        {
            currentOrder.ClearOrder(); // Remove all items from the order
            UpdateOrderSummary(); // Refresh the display
        }

        /// <summary>
        ///     Handles the "Place Order" button click event to finalize the order.
        /// </summary>
        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the current order has any items
            if (currentOrder.OrderItems.Any())
            {
                // Add the current order to the manager's records
                Manager.AddOrder(currentOrder);

                // Notify the user that the order was successfully placed
                MessageBox.Show("Order placed successfully!", "Order Placed", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the current order for a new one
                currentOrder.ClearOrder();

                // Update the order summary
                UpdateOrderSummary();
            }
            else
            {
                // Notify the user if they attempt to place an empty order
                MessageBox.Show("No items in the order!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the "Back to Main Window" button click event to navigate to the MainWindow.
        /// </summary>
        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(); // Create an instance of the main window
            mainWindow.Show(); // Show the main window
            this.Close(); // Close the current food menu window
        }

    }
}
