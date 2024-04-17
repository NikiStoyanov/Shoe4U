namespace Shoe4U.Models.Messages;

using System.ComponentModel.DataAnnotations;

public class CreateMessageInputModel
{
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [EmailAddress(ErrorMessage = "Въведи валиден имейл адрес.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(200, ErrorMessage = "Въведи не повече от 200 символа.")]
    public string Content { get; set; }
}