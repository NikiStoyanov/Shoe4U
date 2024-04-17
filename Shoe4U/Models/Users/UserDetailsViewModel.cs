namespace Shoe4U.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UserDetailsViewModel
{
	public string Id { get; set; }

    [Required(ErrorMessage = "Полето е зад ължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string Name { get; set; }


    [Required(ErrorMessage = "Полето е задължително.")]
    [EmailAddress(ErrorMessage = "Въведи валиден имейл адрес.")]
    public string Email { get; set; }
}
