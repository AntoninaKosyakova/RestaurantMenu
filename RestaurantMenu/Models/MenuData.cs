using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Models
{
    /// <summary>
    /// Represents the structure for saving and loading menu data.
    /// </summary>
    internal class MenuData
    {
        public List<MenuItem> Starters { get; set; }
        public List<MenuItem> MainDishes { get; set; }
        public List<MenuItem> Desserts { get; set; }
    }
}
