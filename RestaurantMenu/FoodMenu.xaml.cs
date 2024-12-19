//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace RestaurantMenu
//{
//    /// <summary>
//    /// Interaction logic for FoodMenu.xaml
//    /// </summary>
//    public partial class FoodMenu : Window
//    {
//        // List of Menu Items for each category
//        private List<MenuItem> _starters;
//        private List<MenuItem> _mainDishes;
//        private List<MenuItem> _desserts;

//        /// <summary>
//        /// Constructor for the FoodMenuWindow class.
//        /// Initializes components and loads menu items.
//        /// </summary>
//        public FoodMenu()
//        {
//            InitializeComponent(); // Initializes the WPF components from XAML
//            LoadMenuItems(); // Initialize menu items
//            PopulateMenu();  // Populate UI dynamically
//        }

       

//        /// <summary>
//        ///      Load menu items into categories.
//        /// </summary>
//        private void LoadMenuItems()
//        {
//            _starters = new List<MenuItem>
//            {
//                new MenuItem("Bruschetta al Pomodoro", "Grilled bread topped with fresh tomatoes, garlic, olive oil, and basil.", 6.00, MenuItem.CategoryEnum.Starters, "Images/bread.jpeg"),
//                new MenuItem("Caprese Salad", "Fresh mozzarella, tomatoes, basil, drizzled with balsamic glaze.", 9.50, MenuItem.CategoryEnum.Starters, "Images/Salad.jpg")
//            };

//            _mainDishes = new List<MenuItem>
//            {
//                new MenuItem("Lasagna al Forno", "Layers of pasta, Bolognese sauce, béchamel, and parmesan cheese.", 10.00, MenuItem.CategoryEnum.MainDish, "Images/Lasagna.png"),
//                new MenuItem("Risotto ai Funghi", "Creamy Arborio rice cooked with mushrooms, garlic, and parmesan.", 12.00, MenuItem.CategoryEnum.MainDish, "Images/MushroomRisotto.png")
//            };

//            _desserts = new List<MenuItem>
//            {
//                new MenuItem("Tiramisu", "Layers of espresso-soaked ladyfingers, mascarpone cream, and cocoa powder.", 4.50, MenuItem.CategoryEnum.Dessert, "Images/Tiramisu.png"),
//                new MenuItem("Panna Cotta", "Silky cooked cream dessert served with a berry coulis or caramel sauce.", 6.99, MenuItem.CategoryEnum.Dessert, "Images/PannaCotta.jpg")
//            };
//        }


//        /// <summary>
//        ///      Dynamically populate the menu sections.
//        /// </summary>
//        private void PopulateMenu()
//        {
//            AddMenuItemsToGroup(StartersPanel, _starters);
//            AddMenuItemsToGroup(MainDishesPanel, _mainDishes);
//            AddMenuItemsToGroup(DessertsPanel, _desserts);
//        }


//        /// <summary>
//        ///     Adds menu items to a StackPanel dynamically.
//        /// </summary>
//        private void AddMenuItemsToGroup(StackPanel panel, List<MenuItem> items)
//        {
//            foreach (MenuItem item in items)
//            {
//                StackPanel menuItemPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

//                // Display name
//                TextBlock nameBlock = new TextBlock
//                {
//                    Text = $"{item.Name} - ${item.Price:F2}",  // Format the text
//                    Foreground = System.Windows.Media.Brushes.White,
//                    Width = 300
//                };

//                // Add button
//                Button addButton = new Button
//                {
//                    Content = "Add",
//                    Width = 50,
//                    Tag = item // Store the MenuItem object in the button's Tag property
//                };
//                addButton.Click += AddToOrder_Click;

//                // Add to the panel
//                menuItemPanel.Children.Add(nameBlock);
//                menuItemPanel.Children.Add(addButton);

//                // Add this panel to the parent StackPanel
//                panel.Children.Add(menuItemPanel);
//            }
//        }

//        /// <summary>
//        /// Adds an item to the order list when the Add button is clicked.
//        /// </summary>
//        private void AddToOrder_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = sender as Button; // Explicitly defining the type
//            MenuItem item = button?.Tag as MenuItem; // Explicitly defining the type

//            if (item != null)
//            {
//                // Add the item to the order (assuming you have an Order object to track this)
//                OrderListBox.Items.Add(item.ToString());  // Using ToString() for display

//                // Update total price (assuming you have a variable to store it)
//                double total = 0;
//                foreach (object orderItem in OrderListBox.Items) // Explicitly using object type
//                {
//                    MenuItem menuItem = orderItem as MenuItem; // Explicitly defining the type
//                    if (menuItem != null)
//                    {
//                        total += menuItem.Price;
//                    }
//                }
//                TotalPriceBox.Text = total.ToString("F2");
//            }
//        }


//        /// <summary>
//        /// Placeholder for the "Place Order" button click event handler.
//        /// </summary>
//        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
//        {
//            // Place order logic here (e.g., save to database or show a confirmation message)
//            MessageBox.Show("Your order has been placed!");
//        }

//        /// <summary>
//        /// Placeholder for the "View Past Orders" button click event handler.
//        /// </summary>
//        private void ViewOrders_Click(object sender, RoutedEventArgs e)
//        {
//            // View past orders logic here
//            MessageBox.Show("View past orders!");
//        }

//    }
//}
