using RestaurantMenu.Models;
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

            DataContext = this;

            EditCommand = new RelayCommand(EditItem);
            DeleteCommand = new RelayCommand(DeleteItem);
        }

        public List<MenuItem> Starters
        {
            get { return MenuManager.Starters; }
        }

        public List<MenuItem> MainDishes
        {
            get { return MenuManager.MainDishes; }
        }

        public List<MenuItem> Desserts
        {
            get { return MenuManager.Desserts; }
        }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public void RefreshUI()
        {
            DataContext = null;
            DataContext = this;
        }

        private void EditItem(object parameter)
        {
            if (parameter is MenuItem item)
            {
                var list = MenuManager.GetListForItem(item);
                if (list != null)
                {
                    EditItem editWindow = new EditItem(item, list)
                    {
                        Owner = this
                    };

                    // Check if the edit was successful
                    if (editWindow.ShowDialog() == true)
                    {
                        // Update the item in the MenuManager
                        MenuManager.UpdateItem(item, editWindow.EditedItem);
                        RefreshUI(); // Refresh UI after editing
                    }
                }
            }
        }


        private void DeleteItem(object parameter)
        {
            if (parameter is MenuItem item)
            {
                MenuManager.RemoveItem(item); // Use RemoveItem to persist changes
                MessageBox.Show($"{item.Name} has been removed.", "Item Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshUI();
            }
        }

        private void AddStarter_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(MenuManager.Starters);
            addItemWindow.Owner = this;
            addItemWindow.ShowDialog();
            RefreshUI();
        }

        private void AddMainDish_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(MenuManager.MainDishes);
            addItemWindow.Owner = this;
            addItemWindow.ShowDialog();
            RefreshUI();
        }

        private void AddDessert_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(MenuManager.Desserts);
            addItemWindow.Owner = this;
            addItemWindow.ShowDialog();
            RefreshUI();
        }

        private void ViewFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            FoodMenuWindow foodMenuWindow = new FoodMenuWindow();
            foodMenuWindow.Show();
            this.Close();
        }

        private void DailySalesSummary_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Total Sales Today: {MenuManager.DailySalesTotal:C}", "Daily Sales Summary", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
