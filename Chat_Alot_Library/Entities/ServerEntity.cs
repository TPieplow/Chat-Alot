using Chat_Alot_Library.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ServerEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string IconURL { get; set; } = null!;
    public string ServerDescription { get; set; } = null!;
    public ICollection<UserEntity>? Members { get; set; }
    public ICollection<ChannelEntity> Channels { get; set; } = null!;
}
