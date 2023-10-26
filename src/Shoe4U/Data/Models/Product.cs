namespace Shoe4U.Data.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public decimal Price { get; set; }

    public int Availability { get; set; }

    public string Color { get; set; }

    public string Material { get; set; }

    public string Brand { get; set; }

    public string Size { get; set; }

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
}