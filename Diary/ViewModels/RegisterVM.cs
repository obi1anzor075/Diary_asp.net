using System.ComponentModel.DataAnnotations;

namespace Diary.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(3, ErrorMessage = "Ваше имя слишком короткое")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Введите корректный адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите корректный адрес электронной почты")] 
        public string? Email { get; set; }

        [Required(ErrorMessage = "Введите правильный пароль")]
        [DataType(DataType.Password, ErrorMessage = "Введите правильный пароль")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password, ErrorMessage = "Введите правильный пароль")]
        [Display(Name = "Подтвердите пароль")]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Adress { get; set; }

        [Required(ErrorMessage ="Вы не согласились с правилами использования")]
        public bool? TermOfService { get; set; }
    }
}
