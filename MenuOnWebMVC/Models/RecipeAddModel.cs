using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MenuOnWebMVC.Models
{
    public class RecipeAddModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Поле назва не може бути пустим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле опис не може бути пустим")]
        [Display(Name = "Опис")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Додайте зображення")]
        [Display(Name = "Зображення")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required(ErrorMessage = "Поле інгрідієнти не може бути пустим")]
        [Display(Name = "Інгрідієнти (Через кому)")]
        public string IngridietsString { get; set; }
    }
}