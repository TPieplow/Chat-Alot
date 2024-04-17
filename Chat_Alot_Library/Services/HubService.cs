//using Microsoft.AspNetCore.SignalR.Client;
//using Microsoft.AspNetCore.Components;
//using Infrastructure.Models;
//using Infrastructure.Factories;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Infrastructure.Repositories;


//namespace Infrastructure.Services
//{
//    public class HubService(NavigationManager navigation, HubConnection connection, MessageRepository repository)
//    {
//        private NavigationManager _navigation = navigation;
//        private HubConnection _connection = connection;
//        private readonly MessageRepository _messageRepository = repository;

//        public async Task InitializeConnection()
//        {
//            try
//            {
//                if (_connection == null)
//                {
//                    _connection = new HubConnectionBuilder()
//                        .WithUrl(_navigation.ToAbsoluteUri("/chathub"))
//                        .Build();

//                    _connection.On<string, string>("RecieveMessage", (user, message) =>
//                    {
//                        var encodedMessage = $"{user}: {message}";
//                    });

//                    await _connection.StartAsync();
//                }
//            }
//            catch (Exception) { }
//        }

//        public async Task Send(string userInput) => await _connection.SendAsync("SendMessage", userInput);

//        public async Task SendMessage(MessageModel model)
//        {
//            var messageEntity = MessageFactory.Create(model);
//            if (messageEntity is not null)
//            {
//                await _messageRepository.CreateOneAsync(messageEntity);
//            }
//        }
//    }
//}


