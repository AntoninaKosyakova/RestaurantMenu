using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    public class MenuItem
    {
        // Private fields for the data
        private string name;
        private string description;
        private double price;
        private CategoryEnum category;
        private string imagePath;
        private const int SPACE = -40;

        // Enum for Category
        public enum CategoryEnum
        {
            Starters,
            MainDish,
            Dessert
        }

        /// <summary>
        /// Initializes a new instance of the MenuItem class with the specified details.
        /// </summary>
        /// <param name="name">The name of the food item.</param>
        /// <param name="description">A short description of the food item.</param>
        /// <param name="price">The price of the food item. Must be non-negative.</param>
        /// <param name="category">The category of the food item (e.g., Starters, MainDish, Dessert).</param>
        /// <param name="imagePath">The file path of the food item's image.</param>
        public MenuItem(string name, string description, double price, CategoryEnum category, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            ImagePath = imagePath;
        }

        /// <summary>
        /// Gets or sets the name of the food item.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty.");
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
                    throw new ArgumentNullException(nameof(Description), "Description cannot be null or empty.");
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
                    throw new ArgumentOutOfRangeException(nameof(Price), "Price cannot be negative.");
                }
                price = value;
            }
        }

        /// <summary>
        /// Gets or sets the category of the food item.
        /// </summary>
        public CategoryEnum Category
        {
            get { return category; }
            set
            {
                if (!Enum.IsDefined(typeof(CategoryEnum), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Category), "Invalid category.");
                }
                category = value;
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
                    throw new ArgumentNullException(nameof(ImagePath), "ImagePath cannot be null or empty.");
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
            return $"{Name,SPACE}{Price:C}\n{Description}";
        }
    }
}
   


