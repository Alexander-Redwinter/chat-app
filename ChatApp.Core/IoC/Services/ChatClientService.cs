using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    public class ChatClientService
    {
        HubConnection connection;
        public async Task Connect()
        {
            //TODO move connection url
            connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/chat").Build();
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async void Send(string message)
        {
            //TODO hardcoded id
            var product = new
            {
                Message = message,
                From = "Me",
                To = "KrFScHUfFQXDL14gNs83SQ"
            };


            string json = JsonConvert.SerializeObject(product);
            try
            {
                await connection.InvokeAsync("SendMessageAsync", json);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
