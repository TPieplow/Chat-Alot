using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Alot_Library.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string AddressLine2 { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    [ForeignKey(nameof(UserEntity))]
    public string UserId { get; set; } = null!;
}
