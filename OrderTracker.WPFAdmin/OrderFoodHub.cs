using Microsoft.AspNet.SignalR;
using OrderTracker.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderTracker.WPFAdmin
{
    public class OrderFoodHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
        public void OrderFood(List<FoodItem> foodList, string orderNumber)
        {
            Clients.All.OrderFood(foodList, orderNumber);
        }
        public void UpdateOrderStatus(string orderId, int foodid, int statusPercentage)
        {
            Clients.All.UpdateOrderStatus(orderId, foodid, statusPercentage);
        }
        public void OrderAcceptance(string orderId, bool status)
        {
            Clients.All.OrderAcceptance(orderId, status);
            
        }
        public override Task OnConnected()
        {
            //Use Application.Current.Dispatcher to access UI thread from outside the MainWindow class
            //Application.Current.Dispatcher.Invoke(() =>
            //    ((MainWindow)Application.Current.MainWindow).WriteToConsole("Client connected: " + Context.ConnectionId));

            return base.OnConnected();
        }
        //public override Task OnDisconnected()
        //{
        //    //Use Application.Current.Dispatcher to access UI thread from outside the MainWindow class
        //    //Application.Current.Dispatcher.Invoke(() =>
        //    //    ((MainWindow)Application.Current.MainWindow).WriteToConsole("Client disconnected: " + Context.ConnectionId));

        //    return base.OnDisconnected();
        //}
    }
}
