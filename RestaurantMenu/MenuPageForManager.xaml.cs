using System.Windows;

namespace RestaurantMenu
{
    public partial class MenuPage : Window
    {
        public MenuPage()
        {
            InitializeComponent();

            // Bind Manager's lists to the XAML elements
            DataContext = this;
        }

        public List<MenuItem> Starters => Manager.Starters;
        public List<MenuItem> MainDishes => Manager.MainDishes;
        public List<MenuItem> Desserts => Manager.Desserts;

        public void RefreshUI()
        {
            DataContext = null; // Clear the binding
            DataContext = this; // Rebind the updated data
        }

        private void EditStarter1_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(Starters[0], Starters);
            editTheItem.Owner = this; // Set the current MenuPage as the owner
            editTheItem.ShowDialog(); // Use ShowDialog to make it a modal window

            // Refresh the UI after returning from EditItem
            RefreshUI();
        }

        // Repeat similar logic for other edit button event handlers
        private void EditStarter2_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(Starters[1], Starters);
            editTheItem.Owner = this;
            editTheItem.ShowDialog();
            RefreshUI();
        }

        private void EditMain1_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(MainDishes[0], MainDishes);
            editTheItem.Owner = this;
            editTheItem.ShowDialog();
            RefreshUI();
        }

        private void EditMain2_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(MainDishes[1], MainDishes);
            editTheItem.Owner = this;
            editTheItem.ShowDialog();
            RefreshUI();
        }

        private void EditDessert1_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(Desserts[0], Desserts);
            editTheItem.Owner = this;
            editTheItem.ShowDialog();
            RefreshUI();
        }

        private void EditDessert2_Click(object sender, RoutedEventArgs e)
        {
            EditItem editTheItem = new EditItem(Desserts[1], Desserts);
            editTheItem.Owner = this;
            editTheItem.ShowDialog();
            RefreshUI();
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