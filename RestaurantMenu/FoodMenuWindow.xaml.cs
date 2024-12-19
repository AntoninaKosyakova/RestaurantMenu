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
        // List of Menu Items for each category
        private List<MenuItem> _starters;
        private List<MenuItem> _mainDishes;
        private List<MenuItem> _desserts;

        // List to keep track of items in the current order
        private List<MenuItem> order;


        /// <summary>
        ///     Constructor for the FoodMenuWindow class.
        ///     Initializes components and loads menu items.
        /// </summary>
        public FoodMenuWindow()
        {
            InitializeComponent(); // Initializes the WPF components from XAML
            order = new List<MenuItem>(); //// Initialize the order list
            // Initialize menu items
            _starters = Manager._starters;

            PopulateMenu();  // Populate UI dynamically

        }



        ///// <summary>
        /////      Load menu items into categories.
        ///// </summary>
        //private void LoadMenuItems()
        //{
        //    _starters = new List<MenuItem>
        //    {
        //       new MenuItem("Bruschetta al Pomodoro", "Grilled bread topped with fresh tomatoes, garlic, olive oil, and basil.", 6.00, "/Images/bread.jpg"),
        //       new MenuItem("Caprese Salad", "Fresh mozzarella, tomatoes, basil, drizzled with balsamic glaze.", 9.50, "/Images/Salad.jpg")
        //    };

        //    _mainDishes = new List<MenuItem>
        //    {
        //         new MenuItem("Lasagna al Forno", "Layers of pasta, Bolognese sauce, béchamel, and parmesan cheese.", 10.00, "/Images/Lasagna.png"),
        //         new MenuItem("Risotto ai Funghi", "Creamy Arborio rice cooked with mushrooms, garlic, and parmesan.", 12.00, "/Images/MushroomRisotto.png")
        //    };

        //    _desserts = new List<MenuItem>
        //    {
        //        new MenuItem("Tiramisu", "Layers of espresso-soaked ladyfingers, mascarpone cream, and cocoa powder.", 4.50, "/Images/Tiramisu.png"),
        //        new MenuItem("Panna Cotta", "Silky cooked cream dessert served with a berry coulis or caramel sauce.", 6.99, "/Images/PannaCotta.png")
        //    };
        //}

        /// <summary>
        ///      Dynamically populate the menu sections.
        /// </summary>
        private void PopulateMenu()
        {
            // Populate the panels
            PopulatePanel(StartersPanel, _starters);
            PopulatePanel(MainDishesPanel, _mainDishes);
            PopulatePanel(DessertsPanel, _desserts);
        }



        /// <summary>
        ///     Populates a specific panel with buttons for each menu item.
        /// </summary>
        /// <param name="panel">The StackPanel to populate.</param>
        /// <param name="menuItems">The list of menu items to add to the panel.</param>
        private void PopulatePanel(StackPanel panel, List<MenuItem> menuItems)
        {
            // Clear any existing content in the panel
            panel.Children.Clear();

            // Create a new Grid for each panel
            Grid itemGrid = new Grid();

            // Add a button for each menu item
            foreach (MenuItem item in menuItems)
            {
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

                // Create a horizontal StackPanel to hold the TextBlock and Button
                StackPanel itemPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5) // Add some spacing around the panel
                };

                //// Create the TextBlock for the item name/description
                TextBlock dishContent = new TextBlock
                {
                    Text = item.ToString(),
                    FontSize = 8,
                    Margin = new Thickness(5, 0, 10, 0), // Add spacing between TextBlock and Button
                    Foreground = new SolidColorBrush(Colors.White)
                };

                // Create the Image for the dish
                Image imgDish = new Image
                {
                    Source = new BitmapImage(new Uri(item.ImagePath, UriKind.RelativeOrAbsolute)),
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(5, 0, 10, 0),
                    
                };

                // Create a button for the menu item
                Button button = new Button
                {
                    Content = "add", // Button label
                    Tag = item, // Store the MenuItem object in the button's Tag property
                    //Margin = new Thickness(5), // Add some spacing around the button
                    FontSize = 10,
                    Height = 20,
                    Width = 20

                };

                // Attach a click event handler to the button
                button.Click += AddToOrder_Click;


                // Add the TextBlock and Button to the StackPanel
                itemPanel.Children.Add(imgDish);
                itemPanel.Children.Add(dishContent);
                itemPanel.Children.Add(button);

                // Add the StackPanel to the appropriate parent panel
                panel.Children.Add(itemPanel);
            }
        }

        /// <summary>
        ///     Handles the click event for menu item buttons, adding the item to the order.
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
        ///     Updates the "Your Order" section with the current list of ordered items.
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
