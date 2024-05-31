using System.ComponentModel.DataAnnotations;

public class CreateAccountModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a username.")]
    public string Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password.")]
    public string Password { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password.")]
    public string ConfirmPassword { get; set; }
}