namespace Shoe4U.Data.Models;

public class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public decimal TotalSum { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
}