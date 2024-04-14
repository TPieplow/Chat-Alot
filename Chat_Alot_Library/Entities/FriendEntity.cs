using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Alot_Library.Entities;

public class FriendEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(UserEntity))]
    public string UserId { get; set; } = null!;
    public UserEntity? Friend { get; set; }
}
