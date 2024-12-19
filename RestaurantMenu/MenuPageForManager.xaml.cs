using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantMenu
{
    public partial class MenuPage : Window
    {
        public List<MenuItem> Starters { get; set; }
        public List<MenuItem> MainDishes { get; set; }
        public List<MenuItem> Desserts { get; set; }

        public MenuPage()
        {
            InitializeComponent();

            // Create some sample menu items
            Starters = new List<MenuItem>
            {
               new MenuItem("Bruschetta al Pomodoro", "Grilled bread topped with fresh tomatoes, garlic, olive oil, and basil.", 6.00, MenuItem.CategoryEnum.Starters, "/Images/bread.jpg"),
               new MenuItem("Caprese Salad", "Fresh mozzarella, tomatoes, basil, drizzled with balsamic glaze.", 9.50, MenuItem.CategoryEnum.Starters, "/Images/Salad.jpg")
            };

            MainDishes = new List<MenuItem>
            {
                 new MenuItem("Lasagna al Forno", "Layers of pasta, Bolognese sauce, béchamel, and parmesan cheese.", 10.00, MenuItem.CategoryEnum.MainDish, "/Images/Lasagna.png"),
                 new MenuItem("Risotto ai Funghi", "Creamy Arborio rice cooked with mushrooms, garlic, and parmesan.", 12.00, MenuItem.CategoryEnum.MainDish, "/Images/MushroomRisotto.png")
            };

            Desserts = new List<MenuItem>
            {
                new MenuItem("Tiramisu", "Layers of espresso-soaked ladyfingers, mascarpone cream, and cocoa powder.", 4.50, MenuItem.CategoryEnum.Dessert, "/Images/Tiramisu.png"),
                new MenuItem("Panna Cotta", "Silky cooked cream dessert served with a berry coulis or caramel sauce.", 6.99, MenuItem.CategoryEnum.Dessert, "/Images/PannaCotta.png")
            };

            // Bind to the XAML elements
            DataContext = this;
        }
    }
}

