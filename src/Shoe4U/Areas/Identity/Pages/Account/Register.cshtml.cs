using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shoe4U.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Shoe4U.Areas.Identity.Pages.Account;

[AllowAnonymous]
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
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(60, ErrorMessage = "Името трябва да бъде поне {2} и максимално {1} символа дълго.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [EmailAddress(ErrorMessage = "Имейлът не е валиден.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(100, ErrorMessage = "Паролата трябва да бъде поне {2} и максимално {1} символа дълга.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Phone(ErrorMessage = "Телефонният номер не е валиден.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public DateTime DateOfBirth { get; set; }
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
            PhoneNumber = Input.PhoneNumber,
            DateOfBirth = Input.DateOfBirth,
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
