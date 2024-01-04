namespace Shoe4U.Data.Models;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{ 
    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}