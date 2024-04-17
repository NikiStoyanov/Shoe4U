namespace Shoe4U.Models.Orders;

using System.ComponentModel.DataAnnotations;

public class CreateOrderInputModel
{
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    public string PhoneNumber { get; set; }
}