using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Net.Http;

namespace OrderTracker.Server
{
    internal class Program
    {
        public static IDisposable SignalR { get; set; }
        private static  string ServerURI = "http://localhost:8081";
        private static  string ServerURIForChat = "http://localhost:8081/signalr";
        public static HubConnection Connection { get; set; }
        public static IHubProxy HubProxy { get; set; }

        private  static void Main(string[] args)
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
                Connection = new HubConnection(ServerURIForChat);
                
                Connection.Closed += Connection_Closed;
                HubProxy = Connection.CreateHubProxy("PayDCSignalRHub");
                HubProxy.On<string, string>("AddMessage", (name, message) =>
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
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.Ma();
        }
    }
}

