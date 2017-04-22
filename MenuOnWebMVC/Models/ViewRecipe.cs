using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace MenuOnWebMVC.Models
{
    public class ViewRecipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Поле назва не може бути пустим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле опис не може бути пустим")]
        [Display(Name = "Опис")]
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public int Likes { get; set; }

        public string[] Tags { get; set; }

        [Required(ErrorMessage = "Поле інгрідієнти не може бути пустим")]
        [Display(Name = "Інгрідієнти (Через кому)")]
        public string IngridietsString { get; set; }

        public static explicit operator ViewRecipe(Recipe recipeEntity)
        {
            var likes = recipeEntity.Likes.Sum(i => i.Value);
            string[] tags = recipeEntity.Tags.Split(',');
            for(int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].Trim();
            }

            ViewRecipe recipe = new ViewRecipe()
            {
                Id = recipeEntity.Id,
                UserId = recipeEntity.UserId,
                Name = recipeEntity.Name,
                Text = recipeEntity.Text,
                ImageUrl = recipeEntity.ImageUrl,
                Likes = likes,
                Tags = tags,
                IngridietsString = recipeEntity.Tags
            };

            return recipe;
        }

        public static explicit operator Recipe(ViewRecipe recipe)
        {

            //StringBuilder tags = new StringBuilder();
            //if (recipe.Tags != null)
            //{
            //    tags.Append(recipe.Tags[0]);
            //    for (var i = 1; i < recipe.Tags.Length; i++)
            //    {
            //        tags.Append($", {recipe.Tags[i]}");
            //    }
            //}
            Recipe recipeEntity = new Recipe()
            {
                Id = recipe.Id,
                UserId = recipe.UserId,
                Name = recipe.Name,
                Text = recipe.Text,
                ImageUrl = recipe.ImageUrl,
                Tags = recipe.IngridietsString,
                CreateDate = DateTime.Now
            };

            return recipeEntity;
        }

        public void UpdateTags()
        {
            string[] tags = IngridietsString.Split(',');
            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].Trim();
            }
            Tags = tags;
        }
    }
}