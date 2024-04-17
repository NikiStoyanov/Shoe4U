namespace Shoe4U.Models.Reviews;

using Products;

public class CreateReviewInputModel
{
    public string Content { get; set; }

    public int ProductId { get; set; }

    public bool IsCurrentProductInCart { get; set; }

    public ProductDetailsViewModel Product { get; set; }
}
