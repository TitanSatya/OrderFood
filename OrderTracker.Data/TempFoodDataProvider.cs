using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Data
{
    public class TempFoodDataProvider : IFoodDataProvider
    {
        public Tuple<FoodItem, bool, string> AddNewFoodItem(FoodItem foodItem)
        {
            return new Tuple<FoodItem, bool, string>(null, false, string.Empty);
        }

        private List<FoodItem> PopulateFoodItems()
        {
            List<FoodItem> fooditems = new List<FoodItem>();
            fooditems.Add(new FoodItem()
            {
                FoodId = 1,
                FoodName = "Manchow Soup",
                FoodDesc = "Delicious Manchow Soup",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = true,
                Price = 100.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 2,
                FoodName = "Chilli Paneer",
                FoodDesc = "Delicious Chilli Paneer Cooked with chilli and paneer",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = true,
                Price = 150.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 3,
                FoodName = "Baby Corn Manchurian",
                FoodDesc = "Delicious Baby Corn with chinese salts",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = true,
                Price = 180.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 4,
                FoodName = "Paneer 65",
                FoodDesc = "Delicious Paneer 65",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = true,
                Price = 170.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 5,
                FoodName = "Gobi Manchurian",
                FoodDesc = "Delicious Gobi Manchurian",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = true,
                Price = 120.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 6,
                FoodName = "Chilli Prawns",
                FoodDesc = "Delicious Tiger prawans with pepper and salt.",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = false,
                Price = 230.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 7,
                FoodName = "Apollo Fish",
                FoodDesc = "Delicious Apollo Fish cooked with olive oil",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = false,
                Price = 360.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 8,
                FoodName = "Chiken Drumsticks",
                FoodDesc = "Delicious Chiken Drumsticks",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = false,
                Price = 250.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 9,
                FoodName = "Chiken Manchurian",
                FoodDesc = "Delicious Chiken Manchurian",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = false,
                Price = 210.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 10,
                FoodName = "Chilli Chiken",
                FoodDesc = "Delicious Chilli Chiken",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = false,
                Price = 200.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 11,
                FoodName = "Pepper Chiken",
                FoodDesc = "Delicious Pepper Chiken",
                ContainsEgg = false,
                FoodType = FoodType.Staters,
                IsVeg = false,
                Price = 160.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 12,
                FoodName = "Palak Paneer",
                FoodDesc = "Delicious Palak Paneer",
                ContainsEgg = false,
                FoodType = FoodType.MainCourse,
                IsVeg = true,
                Price = 110.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 13,
                FoodName = "Kadai Paneer",
                FoodDesc = "Delicious Manchow Soup",
                ContainsEgg = false,
                FoodType = FoodType.MainCourse,
                IsVeg = true,
                Price = 180.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 14,
                FoodName = "Malai Kofta",
                FoodDesc = "Delicious Malai Kofta",
                ContainsEgg = false,
                FoodType = FoodType.MainCourse,
                IsVeg = true,
                Price = 190.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 15,
                FoodName = "Nizami Handi",
                FoodDesc = "Delicious Nizami Handi",
                ContainsEgg = false,
                FoodType = FoodType.MainCourse,
                IsVeg = true,
                Price = 200.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 16,
                FoodName = "Kadai Chiken",
                FoodDesc = "Delicious Kadai Chiken",
                ContainsEgg = false,
                FoodType = FoodType.MainCourse,
                IsVeg = false,
                Price = 400.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 17,
                FoodName = "Chiken Biriyani",
                FoodDesc = "Delicious Chiken Biriyani",
                ContainsEgg = false,
                FoodType = FoodType.Rice,
                IsVeg = false,
                Price = 450.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 18,
                FoodName = "Mutton Biriyani",
                FoodDesc = "Delicious Mutton Biriyani",
                ContainsEgg = false,
                FoodType = FoodType.Rice,
                IsVeg = false,
                Price = 550.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 19,
                FoodName = "Egg Biriyani",
                FoodDesc = "Delicious Egg Biriyani",
                ContainsEgg = true,
                FoodType = FoodType.Rice,
                IsVeg = false,
                Price = 350.00
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 20,
                FoodName = "Egg Noodles",
                FoodDesc = "Delicious Egg Noodles",
                ContainsEgg = true,
                FoodType = FoodType.Noodles,
                IsVeg = false,
                Price = 100
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 21,
                FoodName = "Paneer Margherita",
                FoodDesc = "Delicious Paneer Margherita ",
                ContainsEgg = false,
                FoodType = FoodType.Italian,
                IsVeg = true,
                Price = 450
            }); 
            fooditems.Add(new FoodItem()
            {
                FoodId = 22,
                FoodName = "Chiken Margherita",
                FoodDesc = "Delicious Chiken Margherita",
                ContainsEgg = true,
                FoodType = FoodType.Italian,
                IsVeg = false,
                Price = 550
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 23,
                FoodName = "Egg Chiken Margherita",
                FoodDesc = "Delicious Egg Chiken Margherita",
                ContainsEgg = true,
                FoodType = FoodType.Italian,
                IsVeg = false,
                Price = 600
            });
            fooditems.Add(new FoodItem()
            {
                FoodId = 24,
                FoodName = "Double Cheese Margherita",
                FoodDesc = "Delicious Double Cheese Margherita",
                ContainsEgg = true,
                FoodType = FoodType.Italian,
                IsVeg = false,
                Price = 650
            });
            return fooditems;
        }

        public Tuple<bool, bool, string> DeleteFoodItem(FoodItem foodItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FoodItem> GetFoodItems() => PopulateFoodItems();

        public Tuple<bool, bool, string> UpdateFoodItem(FoodItem foodItem)
        {
            throw new NotImplementedException();
        }
    }
}
