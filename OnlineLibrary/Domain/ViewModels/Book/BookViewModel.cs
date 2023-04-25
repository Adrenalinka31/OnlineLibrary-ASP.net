using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Domain.ViewModels.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Name { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Введите ISBN")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше 6 символов")]
        public string ISBN { get; set; }

        [Display(Name = "Описание")]
        [MinLength(50, ErrorMessage = "Минимальная длина должна быть больше 50 символов")]
        public string Description { get; set; }

        [Display(Name = "Год выпуска")]
        [Required(ErrorMessage = "Укажите год")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string BookYear { get; set; }

        [Display(Name = "Тип книги")]
        [Required(ErrorMessage = "Выберите тип")]
        public string TypeBook { get; set; }

        public string ImageURL { get; set; }

        public IFormFile Avatar { get; set; }

        public byte[]? Image { get;set; }

    }
}
