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
            get { return Manager.Starters; }
        }

        public List<MenuItem> MainDishes
        {
            get { return Manager.MainDishes; }
        }

        public List<MenuItem> Desserts
        {
            get { return Manager.Desserts; }
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
                var list = Manager.GetListForItem(item);
                if (list != null)
                {
                    EditItem editWindow = new EditItem(item, list)
                    {
                        Owner = this
                    };
                    editWindow.ShowDialog();
                    RefreshUI();
                }
            }
        }

        private void DeleteItem(object parameter)
        {
            if (parameter is MenuItem item)
            {
                var list = Manager.GetListForItem(item);
                if (list != null)
                {
                    list.Remove(item);
                    MessageBox.Show($"{item.Name} has been removed.", "Item Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshUI();
                }
            }
        }

        private void AddStarter_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(Manager.Starters);
            addItemWindow.Owner = this;
            addItemWindow.ShowDialog();
            RefreshUI();
        }

        private void AddMainDish_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(Manager.MainDishes);
            addItemWindow.Owner = this;
            addItemWindow.ShowDialog();
            RefreshUI();
        }

        private void AddDessert_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(Manager.Desserts);
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
            MessageBox.Show($"Total Sales Today: {Manager.DailySalesTotal:C}", "Daily Sales Summary", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.ShowDialog();
        }
    }
}
