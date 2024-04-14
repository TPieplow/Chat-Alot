

namespace Chat_Alot_Library.Entities;

public class MessageEntity
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime SentAt { get; set; }
    public string SenderId { get; set; } = null!;
    public string RecieverId { get; set; } = null!;

    public UserEntity? Sender { get; set; }
    public UserEntity? Reciever { get; set; }
}
