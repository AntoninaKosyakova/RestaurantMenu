using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        /// <summary>
        /// Initializes a new instance of the Manager class with a username and password.
        /// </summary>
        /// <param name="username">The manager's login username.</param>
        /// <param name="password">The manager's login password.</param>
        public Manager(string username, string password)
        {
            Username = username;
            Password = password;
            LoadMenuItems();
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

        public static List<MenuItem> Starters { get { return _starters; } }

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

        /// <summary>
        ///      Load menu items into categories.
        /// </summary>
        private static void LoadMenuItems()
        {
            _starters = new List<MenuItem>
            {
               new MenuItem("Bruschetta al Pomodoro", "Grilled bread topped with fresh tomatoes, garlic, olive oil, and basil.", 6.00, "/Images/bread.jpg"),
               new MenuItem("Caprese Salad", "Fresh mozzarella, tomatoes, basil, drizzled with balsamic glaze.", 9.50, "/Images/Salad.jpg")
            };

            _mainDishes = new List<MenuItem>
            {
                 new MenuItem("Lasagna al Forno", "Layers of pasta, Bolognese sauce, béchamel, and parmesan cheese.", 10.00, "/Images/Lasagna.png"),
                 new MenuItem("Risotto ai Funghi", "Creamy Arborio rice cooked with mushrooms, garlic, and parmesan.", 12.00, "/Images/MushroomRisotto.png")
            };

            _desserts = new List<MenuItem>
            {
                new MenuItem("Tiramisu", "Layers of espresso-soaked ladyfingers, mascarpone cream, and cocoa powder.", 4.50, "/Images/Tiramisu.png"),
                new MenuItem("Panna Cotta", "Silky cooked cream dessert served with a berry coulis or caramel sauce.", 6.99, "/Images/PannaCotta.png")
            };
        }

        /// <summary>
        /// Adds a new item to the menu.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        /// <param name="menu">The menu to which the item will be added.</param>
        public void AddMenuItem(MenuItem item, List<MenuItem> menu)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            menu.Add(item);
        }

        /// <summary>
        /// Edits the details of an existing menu item.
        /// </summary>
        /// <param name="item">The menu item with updated details.</param>
        /// <param name="menu">The menu containing the item to be edited.</param>
        public void EditMenuItem(MenuItem item, List<MenuItem> menu)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            MenuItem existingItem = FindExistingMenuItem(item, menu);
            if (existingItem != null)
            {
                existingItem.Description = item.Description;
                existingItem.Price = item.Price;
                //existingItem.Category = item.Category;
                existingItem.ImagePath = item.ImagePath;
            }
            else
            {
                throw new ArgumentException("Menu item not found.");
            }
        }

        /// <summary>
        /// Removes a menu item from the menu.
        /// </summary>
        /// <param name="item">The menu item to remove.</param>
        /// <param name="menu">The menu from which the item will be removed.</param>
        public void RemoveMenuItem(MenuItem item, List<MenuItem> menu)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            MenuItem existingItem = FindExistingMenuItem(item, menu);
            if (existingItem != null)
            {
                menu.Remove(existingItem);
            }
            else
            {
                throw new ArgumentException("Menu item not found.");
            }
        }

        /// <summary>
        /// Finds an existing menu item by its name.
        /// </summary>
        /// <param name="item">The menu item to search for.</param>
        /// <param name="menu">The menu in which to search.</param>
        /// <returns>The existing MenuItem if found, otherwise null.</returns>
        private MenuItem FindExistingMenuItem(MenuItem item, List<MenuItem> menu)
        {
            foreach (MenuItem menuItem in menu)
            {
                if (menuItem.Name == item.Name)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }

}
