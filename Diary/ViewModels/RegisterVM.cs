using System.ComponentModel.DataAnnotations;

namespace Diary.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароль не совпадает.")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Adress {  get; set; }
    }
}
