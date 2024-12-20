using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace RestaurantMenu
{
    public partial class MenuPage : Window
    {
        public MenuPage()
        {
            InitializeComponent();

            // Set the DataContext for data binding
            DataContext = this;

            // Initialize commands for edit and delete actions
            EditCommand = new RelayCommand(EditItem);
            DeleteCommand = new RelayCommand(DeleteItem);
        }

        // Properties to bind the menu sections to the UI
        public List<MenuItem> Starters
        {
            get { return Manager.Starters; } // List of starters
        }

        public List<MenuItem> MainDishes
        {
            get { return Manager.MainDishes; } // List of main dishes
        }

        public List<MenuItem> Desserts
        {
            get { return Manager.Desserts; } // List of desserts
        }


        // ICommand properties for binding buttons to logic
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        // Refresh the UI to reflect updated data
        public void RefreshUI()
        {
            DataContext = null; // Clear the current binding
            DataContext = this; // Rebind the updated data
        }

        // Logic for editing an item
        private void EditItem(object parameter)
        {
            if (parameter is MenuItem item)
            {
                // Fetch the list containing the item
                var list = Manager.GetListForItem(item);
                if (list != null)
                {
                    // Open the EditItem window for the selected item
                    EditItem editWindow = new EditItem(item, list)
                    {
                        Owner = this // Set this window as the owner
                    };
                    editWindow.ShowDialog(); // Display the dialog
                    RefreshUI(); // Update the UI
                }
            }
        }

        // Logic for deleting an item
        private void DeleteItem(object parameter)
        {
            if (parameter is MenuItem item)
            {
                // Fetch the list containing the item and remove it
                var list = Manager.GetListForItem(item);
                if (list != null)
                {
                    list.Remove(item); // Remove the item
                    MessageBox.Show($"{item.Name} has been removed.", "Item Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshUI(); // Update the UI
                }
            }
        }

        // Logic for navigating to the food menu window
        private void ViewFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            FoodMenuWindow foodMenuWindow = new FoodMenuWindow();
            foodMenuWindow.Show();
            this.Close(); // Close the current window
        }

        // Logic for daily sales summary button click
        private void DailySalesSummary_Click(object sender, RoutedEventArgs e)
        {
            // Display a message box showing the total sales for the session
            MessageBox.Show($"Total Sales Today: {Manager.DailySalesTotal:C}",
                            "Daily Sales Summary",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
            );
        }


        // Logic for orders button click
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            // Open the OrdersWindow to view all placed orders
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.ShowDialog();
        }

    }
}
