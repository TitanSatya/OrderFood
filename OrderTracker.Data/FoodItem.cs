using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Data
{
    public class FoodItem
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDesc { get; set; }
        public bool IsVeg { get; set; }
        public bool ContainsEgg { get; set; }
        public double Price { get; set; }
        public FoodType FoodType { get; set; }
    }
}
