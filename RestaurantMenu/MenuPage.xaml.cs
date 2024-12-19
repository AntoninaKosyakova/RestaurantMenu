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
                new MenuItem("Bruschetta", "Grilled bread topped with fresh tomatoes and basil.", 8.99, MenuItem.CategoryEnum.Starters, "bruschetta.jpg"),
                new MenuItem("Spring Rolls", "Crispy rolls filled with vegetables and served with dipping sauce.", 6.49, MenuItem.CategoryEnum.Starters, "spring_rolls.jpg")
            };

            MainDishes = new List<MenuItem>
            {
                new MenuItem("Spaghetti Carbonara", "Classic Italian pasta with eggs, cheese, pancetta, and pepper.", 15.99, MenuItem.CategoryEnum.MainDish, "spaghetti_carbonara.jpg"),
                new MenuItem("Grilled Chicken", "Juicy grilled chicken breast served with mashed potatoes.", 12.99, MenuItem.CategoryEnum.MainDish, "grilled_chicken.jpg")
            };

            Desserts = new List<MenuItem>
            {
                new MenuItem("Tiramisu", "Coffee-flavored Italian dessert made with layers of ladyfingers and mascarpone.", 7.49, MenuItem.CategoryEnum.Dessert, "tiramisu.jpg"),
                new MenuItem("Chocolate Lava Cake", "Warm chocolate cake with a gooey molten center.", 8.99, MenuItem.CategoryEnum.Dessert, "chocolate_lava_cake.jpg")
            };

            // Bind to the XAML elements
            DataContext = this;
        }
    }
}

