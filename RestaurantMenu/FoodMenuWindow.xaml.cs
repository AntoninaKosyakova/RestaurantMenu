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
        // List to keep track of items in the current order
        private List<MenuItem> order;

        /// <summary>
        /// Constructor for the FoodMenuWindow class.
        /// Initializes components and loads menu items from the Manager class.
        /// </summary>
        public FoodMenuWindow()
        {
            InitializeComponent(); // Initializes the WPF components from XAML
            order = new List<MenuItem>(); // Initialize the order list

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
        /// Handles the click event for menu item buttons, adding the item to the order.
        /// </summary>
        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is MenuItem menuItem)
            {
                // Add the selected menu item to the order
                order.Add(menuItem);

                // Update the order summary display
                UpdateOrderSummary();
            }
        }

        /// <summary>
        /// Updates the "Your Order" section with the current list of ordered items.
        /// </summary>
        private void UpdateOrderSummary()
        {
            if (order.Count == 0)
            {
                // If the order is empty, display a placeholder message
                OrderSummary.Text = "No items in your order.";
                return;
            }

            // Clear the current order summary
            OrderSummary.Text = string.Empty;
            double total = 0;

            // Add each item in the order to the summary
            foreach (MenuItem item in order)
            {
                OrderSummary.Text += $"{item.Name} - ${item.Price:F2}\n";
                total += item.Price;
            }

            // Add the total cost to the summary
            OrderSummary.Text += $"\nTotal: ${total:F2}";
        }

        /// <summary>
        /// Clears the current order and resets the "Your Order" section.
        /// </summary>
        private void ClearOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the order list
            order.Clear();

            // Update the order summary display
            UpdateOrderSummary();
        }
    }
}
