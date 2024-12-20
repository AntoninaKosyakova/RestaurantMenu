using System.Windows;

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

            // Bind to the XAML elements
            DataContext = this;
        }

        public void RefreshUI()
        {
            DataContext = null; // Clear the binding
            DataContext = this; // Rebind the updated data
        }


        private void EditStarter1_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(Starters[0], Starters, this);
            editTheItem.Show();
            this.Hide(); // Optionally hide the current window
        }

        private void EditStarter2_Click(object sender, RoutedEventArgs e)
        {
            //open EditItem's window
            EditItem editTheItem = new EditItem(Starters[1], Starters, this);
            editTheItem.Show();
            this.Close();
        }

        private void EditMain1_Click(object sender, RoutedEventArgs e)
        {
            //open EditItem's window
            EditItem editTheItem = new EditItem(MainDishes[0], MainDishes, this);
            editTheItem.Show();
            this.Close();
        }

        private void EditMain2_Click(object sender, RoutedEventArgs e)
        {
            //open EditItem's window
            EditItem editTheItem = new EditItem(MainDishes[1], MainDishes, this);
            editTheItem.Show();
            this.Close();
        }

        private void EditDessert1_Click(object sender, RoutedEventArgs e)
        {
            //open EditItem's window
            EditItem editTheItem = new EditItem(Desserts[0], Desserts, this);
            editTheItem.Show();
            this.Close();
        }

        private void EditDessert2_Click(object sender, RoutedEventArgs e)
        {
            //open EditItem's window
            EditItem editTheItem = new EditItem(Desserts[1], Desserts, this);
            editTheItem.Show();
            this.Close();
        }

        private void DeleteStarter1_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void DeleteStarter2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteMain1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteMain2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteDessert1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteDessert2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DailySalesSummary_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}