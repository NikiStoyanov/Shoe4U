namespace Shoe4U.Models.Products;

using Data.Enums;
using System.ComponentModel.DataAnnotations;
using Reviews;

public class ProductDetailsViewModel
{
	public int Id { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [Range(0, Int32.MaxValue, ErrorMessage = "Въведи положителна наличност.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(20, ErrorMessage = "Въведи поне 20 символа.")]
    [MaxLength(500, ErrorMessage = "Въведи не повече от 500 символа.")]
    public string Description { get; set; }

    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [Range(0, Double.MaxValue, ErrorMessage = "Въведи положителна цена.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Color { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Material { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Size { get; set; }

	public ProductCategory Category { get; set; }
	
    public int CategoryInt { get; set; }

	public DateTime CreatedOn { get; set; }

	public string ImageUrl { get; set; }

	public ICollection<ReviewDetailsOutputModel> Reviews { get; set; } = new HashSet<ReviewDetailsOutputModel>();
}
