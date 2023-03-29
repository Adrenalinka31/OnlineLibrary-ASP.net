using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Domain.Enum
{
    public enum TypeBook
    {
        [Display(Name = "Алгоритмизация")]
        AlgorithmBook = 0,
        [Display(Name = "Программирование")]
        CodingBook = 1,
        [Display(Name = "Математика")]
        MathBook = 2,
        [Display(Name = "История")]
        HistoryBook = 3,
        [Display(Name = "Моделирование")]
        ModelBook = 4

    }
}
