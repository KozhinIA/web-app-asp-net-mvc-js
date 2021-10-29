using Common.Attributes;
using Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WebAppAspNetMvcJs.Models
{
    public class Setting
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        /// <summary>
        /// Тип настройки
        /// </summary> 
        [Required]
        [ScaffoldColumn(false)]
        [Index(IsUnique = true)]
        public SettingType Type { get; set; }

        [Display(Name = "Тип", Order = 10)]
        [UIHint("DropDownList")]
        [TargetProperty("Type")]
        [NotMapped]
        public IEnumerable<SelectListItem> TypeDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (SettingType type in Enum.GetValues(typeof(SettingType)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == Type
                    });
                }

                return dictionary;
            }
        }





        /// <summary>
        /// Значение
        /// </summary>    
        [Required]
        [Display(Name = "Значение", Order = 20)]
        public string Value { get; set; }
    }
}