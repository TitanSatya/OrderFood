using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Data
{
    public interface IDataProvider<T>
    {
        
        IEnumerable<T> GetItems();
        Tuple<T, bool, string> AddItem(T item);
        Tuple<bool, bool, string> UpdateItem(T item);
        Tuple<bool, bool, string> DeleteItem(T item);
    }
}
