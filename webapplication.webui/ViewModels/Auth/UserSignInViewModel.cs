using System.ComponentModel.DataAnnotations;

namespace webapplication.webui.ViewModels
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen email adresinizi girin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
    }
}