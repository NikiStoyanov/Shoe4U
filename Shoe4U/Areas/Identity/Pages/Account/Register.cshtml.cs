namespace Shoe4U.Areas.Identity.Pages.Account;

using System.ComponentModel.DataAnnotations;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public RegisterModel(
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
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

        [Required(ErrorMessage = "Полето е задължително.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new User
        {
            Name = Input.Name,
            UserName = Input.Email,
            Email = Input.Email,
        };

        var result = await _userManager.CreateAsync(user, Input.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToPage("/");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return Page();
    }
}