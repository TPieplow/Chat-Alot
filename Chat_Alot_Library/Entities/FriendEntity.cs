namespace Chat_Alot_Library.Entities;

public class FriendEntity
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string FriendId { get; set; } = null!;

    public UserEntity? User { get; set; }
    public UserEntity? Friend { get; set; }
}
