using System;
using System.Collections.Generic;

namespace OrderTracker.Data
{
    public class TempRestaurantDataProvider : IDataProvider<RestaurantData>
    {
        public TempRestaurantDataProvider()
        {

            Items.Add(new RestaurantData() { RestaurantId = 1, RestaurantName = "Satya Cafe", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 2, RestaurantName = "Anna Cafe", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 3, RestaurantName = "Sampath Dhaba", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 4, RestaurantName = "Priyanka Pancakes", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 5, RestaurantName = "Krishna Bar", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 6, RestaurantName = "Himaja Veg Restaurant", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 7, RestaurantName = "Preethi Hostel", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 8, RestaurantName = "Saran Nellure Mess", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 9, RestaurantName = "Prashanth Coffee", IsAvailable = true });
            Items.Add(new RestaurantData() { RestaurantId = 10, RestaurantName = "Bharath Veg Bhandara", IsAvailable = true });

        }
        public static List<RestaurantData> Items { get; set; } = new List<RestaurantData>();

        public Tuple<RestaurantData, bool, string> AddItem(RestaurantData item)
        {
            try
            {
                Items.Add(item);
            }
            catch (Exception ex)
            {
                return new Tuple<RestaurantData, bool, string>(null, false, ex.ToString());
            }

            return new Tuple<RestaurantData, bool, string>(item, true, string.Empty);
        }

        public Tuple<bool, bool, string> DeleteItem(RestaurantData item)
        {
            try
            {
                Items.Remove(item);
            }
            catch (Exception ex)
            {
                return new Tuple<bool, bool, string>(false, false, ex.ToString());

            }
            return new Tuple<bool, bool, string>(true, true, string.Empty);
        }

        public IEnumerable<RestaurantData> GetItems()
        {
            return Items;
        }

        public Tuple<bool, bool, string> UpdateItem(RestaurantData item)
        {
            throw new NotImplementedException();
        }
    }
}
