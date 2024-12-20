using RestaurantMenu.Models;
using System.Collections.Generic;
using System.Windows;

namespace RestaurantMenu
{
    public class MenuManager
    {
        private static List<MenuItem> _starters;
        private static List<MenuItem> _mainDishes;
        private static List<MenuItem> _desserts;
        private static double _dailySalesTotal = 0;
        private static List<Order> _placedOrders = new List<Order>();

        // Static constructor to ensure menu items are loaded
        static MenuManager()
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

        public static double DailySalesTotal => _dailySalesTotal;

        public static List<Order> PlacedOrders => _placedOrders;

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
            if (Starters.Contains(item)) return Starters;
            if (MainDishes.Contains(item)) return MainDishes;
            if (Desserts.Contains(item)) return Desserts;
            return null;
        }
    }
}
