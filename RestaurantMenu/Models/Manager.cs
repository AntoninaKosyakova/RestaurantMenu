using System.Windows;

namespace RestaurantMenu
{
    public class Manager
    {
        private string username;
        private string password;

        /// <summary>
        /// Initializes a new instance of the Manager class with a username and password.
        /// </summary>
        /// <param name="username">The manager's login username.</param>
        /// <param name="password">The manager's login password.</param>
        public Manager(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the manager's username.
        /// </summary>
        public string Username
        {
            get { return username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    MessageBox.Show("Username cannot be null or empty...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                username = value;
            }
        }

        /// <summary>
        /// Gets or sets the manager's password.
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password cannot be null or empty.");
                }
                password = value;
            }
        }
    }
}
