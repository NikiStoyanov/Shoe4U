namespace Shoe4U.Models.Reviews;

using Products;
using System.ComponentModel.DataAnnotations;

public class CreateReviewInputModel
{
	[Required(ErrorMessage = "Полето е задължително.")]
	[MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
	[MaxLength(200, ErrorMessage = "Въведи не повече от 200 символа.")]
	public string Content { get; set; }

    public int ProductId { get; set; }

    public bool IsCurrentProductInCart { get; set; }

    public bool IsCurrentProductPurchasedBefore { get; set; }

    public ProductDetailsViewModel Product { get; set; }
}
