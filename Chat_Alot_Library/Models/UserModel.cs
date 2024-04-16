using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class UserModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? ProfileImageURL { get; set; } = null!;
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
}
