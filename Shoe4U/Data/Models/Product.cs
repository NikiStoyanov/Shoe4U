namespace Shoe4U.Data.Models;

using Enums;

public class Product
{
    public int Id { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public string Name { get; set; }

    public int Quantity { get; set; }

    public ProductCategory Category { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public decimal Price { get; set; }

    public string Color { get; set; }

    public string Material { get; set; }

    public string Brand { get; set; }

    public string Size { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
}