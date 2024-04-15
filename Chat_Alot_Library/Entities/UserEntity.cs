using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Chat_Alot_Library.Entities;

public class UserEntity : IdentityUser
{
    [Required]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;
    [Required]
    [ProtectedPersonalData]
    public string LastName { get; set;} = null!;
    public string? ProfileImageURL { get; set; } = null!;
    public DateTime? Created {  get; set; }
    public DateTime? Updated { get; set;}

    public ICollection<MessageEntity>? MessageSenders { get; set; }
    public ICollection<MessageEntity>? MessageRecievers { get; set; }
    public ICollection<FriendEntity>? Friends { get; set;}
    public ICollection<AddressEntity>? Addresses { get; set; }
    public ICollection<ServerEntity>? Servers { get; set;}
}
