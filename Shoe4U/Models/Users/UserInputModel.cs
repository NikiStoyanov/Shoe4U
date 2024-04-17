namespace Shoe4U.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UserInputModel
{
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string Name { get; set; }


    [Required(ErrorMessage = "Полето е задължително.")]
    [EmailAddress(ErrorMessage = "Въведи валиден имейл адрес.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [StringLength(100, ErrorMessage = "Паролата трябва да бъде между 6 и 100 символа.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$",
        ErrorMessage = "Паролата трябва да съдържа поне една главна буква, една малка буква, една цифра и един специален символ. Въведи между 6 и 100 символа.")]
    public string Password { get; set; }
}
