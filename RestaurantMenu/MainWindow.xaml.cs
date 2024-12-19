using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///      This is so that when you click on the 'Place Order Button' it goes to the FoodMenuWindow
        /// </summary>
        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Food Menu window
            FoodMenuWindow foodMenuWindow = new FoodMenuWindow();
            foodMenuWindow.Show();
            this.Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
           //open manager's window
           MenuPage menuPageForManager = new MenuPage();
           menuPageForManager.Show();
           this.Close();
        }


    }
}