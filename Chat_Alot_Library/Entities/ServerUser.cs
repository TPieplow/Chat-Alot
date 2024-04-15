using Chat_Alot_Library.Entities;

namespace Infrastructure.Entities;

public class ServerUser
{
    public int ServerId { get; set; }
    public ServerEntity? Server { get; set; }

    public string UserId { get; set; } = null!;
    public UserEntity? User { get; set; }
}
