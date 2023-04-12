using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
    public static class EnumDisplayExtensions
    {
        public static string GetDisplayName(this TypeBook enumValue)
        {
            //определяем тип параметра и извлекаем массив его публичных членов по имени
            MemberInfo[] memberInfo = enumValue.GetType().GetMember(enumValue.ToString());

            //определяем тип класса атрибута
            Type attributeType = typeof(DisplayAttribute);

            //у первого публичного члена пытаемся получить массив
            //атрибутов типа DisplayAttribute
            object[] attributes = memberInfo[0].GetCustomAttributes(attributeType, false);
            //если поиск безуспешен или почему-то таких атрибутов найдено больше одного
            //вываливаем ошибку
            if (attributes == null || attributes.Length != 1)
                throw new ArgumentOutOfRangeException($"Невозможно найти атрибут по имени '{nameof(DisplayAttribute)}'");

            //хватаем атрибут
            var attribute = attributes.SingleOrDefault() as DisplayAttribute;
            //возвращаем значение его свойства по имени Name
            return attribute?.Name;
        }
    }

}
