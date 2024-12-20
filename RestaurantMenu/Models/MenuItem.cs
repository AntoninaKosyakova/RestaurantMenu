using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantMenu.Models
{
    public class MenuItem
    {
        // Private fields for the data
        private string name;
        private string description;
        private double price;
        private string imagePath;
        private const int SPACE = -40;



        /// <summary>
        /// Initializes a new instance of the MenuItem class with the specified details.
        /// </summary>
        /// <param name="name">The name of the food item.</param>
        /// <param name="description">A short description of the food item.</param>
        /// <param name="price">The price of the food item. Must be non-negative.</param>
        /// <param name="imagePath">The file path of the food item's image.</param>
        public MenuItem(string name, string description, double price, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;
        }

        /// <summary>
        ///    Gets or sets the name of the food item.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Name cannot be null or empty...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;
                }
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the food item.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Description cannot be null or empty...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;

                }
                description = value;
            }
        }

        /// <summary>
        /// Gets or sets the price of the food item. Price cannot be negative.
        /// </summary>
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Price cannot be negative...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;

                }
                price = value;
            }
        }

        /// <summary>
        /// Gets or sets the file path of the food item's image.
        /// </summary>
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Image Path cannot be null or empty, make sure it is present in the Images folder for it to show on screen...", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;
                }
                imagePath = value;
            }
        }

        /// <summary>
        /// Returns a string representation of the MenuItem.
        /// </summary>
        /// <returns>A string describing the MenuItem.</returns>
        public override string ToString()
        {
            return $"{Name,SPACE}{Price:C}\n\n{Description}";
        }
    }
}



