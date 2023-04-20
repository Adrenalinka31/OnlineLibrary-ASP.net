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

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Выберите категорию")]
        public string Category { get; set; }

        public string ImageURL { get; set; }

        [Display(Name = "Год выпуска")]
        [Required(ErrorMessage = "Укажите год")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string BookYear { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
