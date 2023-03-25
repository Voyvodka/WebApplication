using System.ComponentModel.DataAnnotations;

namespace webapplication.webui.ViewModels
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz.")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz.")]
        public string Email { get; set; }
    }
}