using Infrastructure.Models;

namespace ChatApp.ViewModels;

public class ChatViewModel
{
    public UserModel User { get; set; } 
    public List<MessageModel> Messages { get; set; } 

    public ChatViewModel() 
    {
        User = new UserModel();
        Messages = new List<MessageModel>();
    }
}
