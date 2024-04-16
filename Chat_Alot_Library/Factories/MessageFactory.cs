using Chat_Alot_Library.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class MessageFactory
{
    public static MessageEntity Create(MessageModel model)
    {
        try 
        {
            var date = DateTime.UtcNow;
            return new MessageEntity()
            {
                Content = model.Content,
                SentAt = date,
                MessageSender = model.MessageSender,
                MessageReviever = model.MessageReviever,
                SenderId = model.SenderId,
                RecieverId = model.RecieverId,
            };
        } catch { }
        return null!;
    }
}

