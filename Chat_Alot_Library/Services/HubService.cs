using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using System.Data;


namespace Infrastructure.Services
{
    public class HubService(NavigationManager navigation, HubConnection connection)
    {
        private NavigationManager _navigation = navigation;
        private HubConnection _connection = connection;
        private List<string> messages = new List<string>();
        private string messageInput;
        

        public async Task InitializeConnection()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new HubConnectionBuilder()
                        .WithUrl(_navigation.ToAbsoluteUri("/chathub"))
                        .Build();

                    IDisposable subscription = _connection.On<string, string>("RecieveMessage", (user, message) =>
                    {
                        var encodedMessage = $"{user}: {message}";
                        messages.Add(encodedMessage);
                        
                    });

                    subscription.Dispose();
                    await _connection.StartAsync();
                }
            }
            catch (Exception) {  }
        }

        public async Task Send(string userInput) => await _connection.SendAsync("SendMessage", userInput ,messageInput);

        public async Task SendMessage(string userInput, string user)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                await _connection.SendAsync("SendMessage", userInput, user);
            }
        }
    }
}


