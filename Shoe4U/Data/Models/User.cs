namespace Shoe4U.Data.Models;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{ 
    public string Name { get; set; }

    public string Basket { get; set; } = "";

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}