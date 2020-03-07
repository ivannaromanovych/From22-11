using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2020_02_15Hello.Models
{
    public class CategoryCreateViewModel
    {
        [Display(Name="Title of category")]
        [Required(ErrorMessage ="Name-field is required")]
        public virtual string Name { get; set; }
        [Display(Name="url-link")]
        [Required(ErrorMessage = "Url-field is required")]
        public virtual string UrlSlug { get; set; }

        public virtual string Description { get; set; }
    }
    public class CategoryItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title of category")]
        public virtual string Name { get; set; }
        [Display(Name = "url-link")]
        public virtual string UrlSlug { get; set; }
    }

}