using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using OrderTracker.Data;
using Owin;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OrderTracker.WebServer
{
    public class WebStartup
    {
        public static IDisposable SignalR { get; set; }
        private static readonly string ServerURI = "http://localhost:8081";
        private static readonly string ServerURIForChat = "http://localhost:8081/signalr";
        public static HubConnection Connection { get; set; }
        public static IHubProxy HubProxy { get; set; }
        public static void Start()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
                Connection = new HubConnection(ServerURIForChat);

                Connection.Closed += Connection_Closed;
                HubProxy = Connection.CreateHubProxy("OrderFoodHub");
               
                HubProxy.On<List<FoodItem>,string> ("OrderFood", (foodItems, orderId) =>
                {

                });
                try
                {
                    Connection.Start();
                }
                catch (HttpRequestException x)
                {
                    throw x;
                    //No connection: Don't enable Send button or show chat UI

                }
            }
            catch (Exception)
            {

                throw;
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
