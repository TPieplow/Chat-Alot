using Chat_Alot_Library.Entities;

namespace Infrastructure.Entities;

public class MutualFriendEntity
{
    public int FriendId { get; set; }
    public FriendEntity? Friend { get; set; }

    public int MutualFriendId { get; set; }
    public FriendEntity? MutualFriend { get; set; }

}
