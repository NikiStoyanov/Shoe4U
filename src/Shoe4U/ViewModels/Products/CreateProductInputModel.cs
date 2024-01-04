namespace Shoe4U.ViewModels.Products;

public class CreateProductInputModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IFormFile Image { get; set; }

    public decimal Price { get; set; }

    public int Availability { get; set; }

    public string Color { get; set; }

    public string Material { get; set; }

    public string Brand { get; set; }

    public string Size { get; set; }
}
