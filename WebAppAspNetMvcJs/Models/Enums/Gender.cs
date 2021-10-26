using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcJs.Models
{
    public enum Gender
    {
        [Display(Name = "Женский")]
        Female = 1,

        [Display(Name = "Мужской")]
        Male = 2,
    }
}