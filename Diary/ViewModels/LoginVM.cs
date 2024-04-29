using System.ComponentModel.DataAnnotations;

namespace Diary.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Введите почту.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Введите пароль.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
