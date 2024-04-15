using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Alot_Library.Entities;

public class FriendEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(UserEntity))]
    public string UserId { get; set; } = null!;
    public string FriendId { get; set; } = null!;
    public bool IsOnline { get; set; }
    public DateTime FriendsSince { get; set; }
    public UserEntity? Friend { get; set; }
    public UserEntity? User { get; set; }
    public ICollection<FriendEntity> MutualFriends { get; set; } = new List<FriendEntity>();
}
