using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using OrderTracker.Data;
using Owin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.WPFClient
{
    public class SignalStartup
    {
        public static IDisposable SignalR { get; set; }
        private static readonly string ServerURI = "http://localhost:8081";
        private static readonly string ServerURIForChat = "http://localhost:8081/signalr";
        public static HubConnection Connection { get; set; }
        public static IHubProxy HubProxy { get; set; }
        public static ObservableCollection<FoodOrder> OrderedFoods { get; set; } = new ObservableCollection<FoodOrder>();
         

        public static void Start()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
            }
            catch (Exception)
            {


            }
            Connection = new HubConnection(ServerURIForChat);

                Connection.Closed += Connection_Closed;
                HubProxy = Connection.CreateHubProxy("OrderFoodHub");

                HubProxy.On<List<FoodItem>, string>("OrderFood", (foodItems, orderId) =>
                {
                    OrderedFoods.Add(new FoodOrder() { OrderId = orderId, FoodItems = foodItems });
                });
                HubProxy.On<string, int, int>("UpdateOrderStatus", (orderId, foodid, statusPercentage) =>
                {

                });
                HubProxy.On<string, bool>("OrderAcceptance", (orderId, status) =>
                {

                });
            try
                {
                    Connection.Start();
                }
                catch (HttpRequestException x)
                {
                    
                    //No connection: Don't enable Send button or show chat UI

                }



         
        }

        private static void Connection_Closed()
        {

        }
    }

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
