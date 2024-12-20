using System.Windows;

namespace RestaurantMenu
{

    public class Manager
    {
        // Private fields for Username and Password
        private string username;
        private string password;

        private static List<MenuItem> _starters;
        private static List<MenuItem> _mainDishes;
        private static List<MenuItem> _desserts;

        // Tracks total sales for the day
        private static double _dailySalesTotal = 0;  // Initial value of 0
        private static List<Order> _placedOrders = new List<Order>(); // List of all placed orders

        // Static constructor to ensure menu items are loaded
        static Manager()
        {
            LoadMenuItems();
        }
      
        /// <summary>
        /// Initializes a new instance of the Manager class with a username and password.
        /// </summary>
        /// <param name="username">The manager's login username.</param>
        /// <param name="password">The manager's login password.</param>
        public Manager(string username, string password)
        {
            Username = username;
            Password = password;
        }

        #region readOnly Prop
        /// <summary>
        ///     Gets the total sales for the session.
        /// </summary>
        public static double DailySalesTotal
        {
            get { return _dailySalesTotal; }
        }

        /// <summary>
        ///     Gets the list of all placed orders.
        /// </summary>
        public static List<Order> PlacedOrders
        {
            get { return _placedOrders; }
        }
        #endregion

        public static List<MenuItem> Starters
        {
            get { return _starters; }
            set { _starters = value; }
        }

        public static List<MenuItem> MainDishes
        {
            get { return _mainDishes; }
            set { _mainDishes = value; }
        }

        public static List<MenuItem> Desserts
        {
            get { return _desserts; }
            set { _desserts = value; }
        }

        /// <summary>
        /// Loads menu items into categories.
        /// </summary>
        private static void LoadMenuItems()
        {
            Starters = new List<MenuItem>
            {
                new MenuItem("Bruschetta al Pomodoro", "Grilled bread topped with fresh tomatoes, garlic, olive oil, and basil.", 6.00, "/Images/bread.jpg"),
                new MenuItem("Caprese Salad", "Fresh mozzarella, tomatoes, basil, drizzled with balsamic glaze.", 9.50, "/Images/Salad.jpg")
            };

            MainDishes = new List<MenuItem>
            {
                new MenuItem("Lasagna al Forno", "Layers of pasta, Bolognese sauce, béchamel, and parmesan cheese.", 10.00, "/Images/Lasagna.png"),
                new MenuItem("Risotto ai Funghi", "Creamy Arborio rice cooked with mushrooms, garlic, and parmesan.", 12.00, "/Images/MushroomRisotto.png")
            };

            Desserts = new List<MenuItem>
            {
                new MenuItem("Tiramisu", "Layers of espresso-soaked ladyfingers, mascarpone cream, and cocoa powder.", 4.50, "/Images/Tiramisu.png"),
                new MenuItem("Panna Cotta", "Silky cooked cream dessert served with a berry coulis or caramel sauce.", 6.99, "/Images/PannaCotta.png")
            };
        }




        /// <summary>
        /// Gets or sets the manager's username.
        /// </summary>
        public string Username
        {
            get { return username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    MessageBox.Show("Username cannot be null or empty...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;
                }
                username = value;
            }
        }

        /// <summary>
        /// Gets or sets the manager's password.
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password cannot be null or empty.");
                }
                password = value;
            }
        }

        public static List<MenuItem> GetListForItem(MenuItem item)
        {
            if (Starters.Contains(item)) return Starters;
            if (MainDishes.Contains(item)) return MainDishes;
            if (Desserts.Contains(item)) return Desserts;
            return null;
        }

        /// <summary>
        ///     Adds a completed order to the records and updates the total sales.
        /// </summary>
        /// <param name="order">The completed order to add.</param>
        public static void AddOrder(Order order)
        {
            if (order != null)
            {
                _placedOrders.Add(order); // Add the order to the list
                _dailySalesTotal += order.TotalPrice; // Add the total price to the daily sales total
            }
        }

    }

}
