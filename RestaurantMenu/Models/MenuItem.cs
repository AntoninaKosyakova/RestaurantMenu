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
        private string imagePath;
        private double price;
        private const int SPACE = -40;

        /// <summary>
        ///     A static list of valid image paths.
        /// </summary>
        public static List<string> ValidImagePaths { get; } = new List<string>
        {
            "/Images/bread.jpg",
            "/Images/Lasagna.png",
            "/Images/MushroomRisotto.png",
            "/Images/PannaCotta.png",
            "/Images/Salad.jpg",
            "/Images/Tiramisu.png",
            "/Images/ChickenParmesan.jpg",
            "/Images/FocacciaBread.jpg",
            "/Images/ChickenPiccata.png",
            "/Images/EggplantCaponata.jpg",
            "/Images/PestoMozzarellaArancini.jpg",
            "/Images/ItalianSalad.jpg"
        };

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
            ImagePath = ValidateImagePath(imagePath);
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
        /// Validates the provided image path.
        /// </summary>
        /// <param name="imagePath">The image path to validate.</param>
        /// <returns>The validated image path.</returns>
        private string ValidateImagePath(string imagePath)
        {
            if (ValidImagePaths.Contains(imagePath))
            {
                return imagePath;
            }

            MessageBox.Show("Invalid image path. Please select a valid path from the list.", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Warning);
            return ValidImagePaths.Count > 0 ? ValidImagePaths[0] : string.Empty; // Default to the first valid path if available.
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



