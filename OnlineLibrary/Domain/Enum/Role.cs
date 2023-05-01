using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Domain.Enum
{
    public enum Role
    {
        [Display(Name = "Пользователь")]
        User = 0,
        [Display(Name = "Moderator")]
        Moderator = 1,
        [Display(Name = "Админ")]
        Admin = 2,
    }
}
