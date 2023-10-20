namespace Shoe4U.Data.Models;

public class Order // Mapping table
{
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public User User { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public decimal TotalPrice { get; set; }
}
