using System.Windows;
using System.Xml.Linq;

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

        // Static constructor to ensure menu items are loaded
        static Manager()
        {
            LoadMenuItems();
        }

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
        /// Initializes a new instance of the Manager class with a username and password.
        /// </summary>
        /// <param name="username">The manager's login username.</param>
        /// <param name="password">The manager's login password.</param>
        public Manager(string username, string password)
        {
            Username = username;
            Password = password;
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



        public List<MenuItem> AddItem(MenuItem newItem, List<MenuItem> list)
        {
            if (list.Count >= 2 || newItem == null)
            {
                MessageBox.Show("List capacity cannot add if there is already 2 dishes...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            list.Add(newItem);
            return list;
        }

        private MenuItem FindMenuItem(MenuItem item, List<MenuItem> list)
        {
            foreach (MenuItem menuItem in list)
            {
                if (menuItem == item)
                    return menuItem;
            }
            return null;
        }

        public List<MenuItem> RemoveItem(MenuItem item, List<MenuItem> list)
        {
            if (item == null)
            {
                MessageBox.Show("Item cannot be null...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            MenuItem itemToRemove = FindMenuItem(item, list);
            if (itemToRemove != null)
                list.Remove(itemToRemove);

            return list;
        }

        public static List<MenuItem> GetListForItem(MenuItem item)
        {
            if (Starters.Contains(item)) return Starters;
            if (MainDishes.Contains(item)) return MainDishes;
            if (Desserts.Contains(item)) return Desserts;
            return null;
        }

    }

}
