namespace Shoe4U.Models.Products;

public class ProductsListingModel
{
    public string ListName { get; set; }

    public List<ProductDetailsViewModel> Products { get; set; }
}
