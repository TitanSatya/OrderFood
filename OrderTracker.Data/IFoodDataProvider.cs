using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Data
{
    public interface IFoodDataProvider
    {
        IEnumerable<FoodItem> GetFoodItems();
        Tuple<FoodItem,bool,string> AddNewFoodItem(FoodItem foodItem);
        Tuple<bool, bool, string> UpdateFoodItem(FoodItem foodItem);
        Tuple<bool, bool, string> DeleteFoodItem(FoodItem foodItem);

    }
}
