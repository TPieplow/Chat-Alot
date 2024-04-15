using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ChannelEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ServerId { get; set; }
    public ServerEntity Server { get; set; } = null!;
}
