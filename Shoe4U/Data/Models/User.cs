namespace Shoe4U.Data.Models;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; }

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}