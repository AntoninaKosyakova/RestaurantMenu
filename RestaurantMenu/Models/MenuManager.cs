using RestaurantMenu.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RestaurantMenu
{
    public class MenuManager
    {
        private static List<MenuItem> _starters;
        private static List<MenuItem> _mainDishes;
        private static List<MenuItem> _desserts;
        private static double _dailySalesTotal = 0;
        private static List<Order> _placedOrders = new List<Order>();

        private static readonly string DataFilePath = "menu_data.json"; // File to store menu data

        // Static constructor to ensure menu items are loaded
        static MenuManager()
        {
            LoadMenuItems();
        }

        public static List<MenuItem> Starters
        {
            get { return _starters; }
            set { _starters = value; SaveMenuItems(); }
        }

        public static List<MenuItem> MainDishes
        {
            get { return _mainDishes; }
            set { _mainDishes = value; SaveMenuItems(); }
        }

        public static List<MenuItem> Desserts
        {
            get { return _desserts; }
            set { _desserts = value; SaveMenuItems(); }
        }

        public static double DailySalesTotal => _dailySalesTotal;

        public static List<Order> PlacedOrders => _placedOrders;

        /// <summary>
        /// Loads menu items from the data file or initializes default items if no file exists.
        /// </summary>
        private static void LoadMenuItems()
        {
            if (File.Exists(DataFilePath))
            {
                // Load from file if it exists
                string json = File.ReadAllText(DataFilePath);
                var data = JsonSerializer.Deserialize<MenuData>(json);

                _starters = data.Starters ?? new List<MenuItem>();
                _mainDishes = data.MainDishes ?? new List<MenuItem>();
                _desserts = data.Desserts ?? new List<MenuItem>();
            }
            else
            {
                // Initialize default items
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

                SaveMenuItems(); // Save the default items to file
            }
        }

        /// <summary>
        /// Saves the current menu items to the data file.
        /// </summary>
        private static void SaveMenuItems()
        {
            var data = new MenuData
            {
                Starters = _starters,
                MainDishes = _mainDishes,
                Desserts = _desserts
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, json);
        }

        public static void AddOrder(Order order)
        {
            if (order != null)
            {
                _placedOrders.Add(order);
                _dailySalesTotal += order.TotalPrice;
            }
        }

        public static List<MenuItem> GetListForItem(MenuItem item)
        {
            if (_starters.Contains(item)) return _starters;
            if (_mainDishes.Contains(item)) return _mainDishes;
            if (_desserts.Contains(item)) return _desserts;
            return null;
        }

        public static void RemoveItem(MenuItem item)
        {
            if (_starters.Remove(item) || _mainDishes.Remove(item) || _desserts.Remove(item))
            {
                SaveMenuItems(); // Persist changes after removal
            }
        }

        public static void UpdateItem(MenuItem oldItem, MenuItem newItem)
        {
            var list = GetListForItem(oldItem);
            if (list != null)
            {
                int index = list.IndexOf(oldItem);
                if (index >= 0)
                {
                    list[index] = newItem;
                    SaveMenuItems(); // Persist changes after update
                }
            }
        }
    }

    
}
