using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcJs.Models
{
    public enum SettingType
    {
        [Display(Name = "Пароль")]
        Password = 1,
    }
}