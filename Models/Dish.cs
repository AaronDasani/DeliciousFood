using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public Int32 dish_id{get;set;}  

        [Display(Name="Name of Dish")]
        [Required]
        [MinLength(3,ErrorMessage="Dish name should be atleast 3 characters")]
        [MaxLength(50,ErrorMessage="Dish name is exceeded the 50 characters limit")]
        public string name{get;set;}

        [Display(Name="Chef's Name")]
        [Required]
        [MinLength(3,ErrorMessage="Chef's Name should be atleast 3 characters")]
        [MaxLength(50,ErrorMessage="Chef's Name is exceeded the 50 characters limit")]
        public string chef{get;set;}

        [Display(Name="Tastiness")]
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage="Invalid Tastiness level")]
        public Int16 tastiness{get;set;}

        [Display(Name="# of Calories")]
        [Required]
        [RegularExpression(@"^(?![0,]+$)\d+$", ErrorMessage="Invalid number of Calories")]
        public Int16 calories{get;set;}

        [Display(Name="Description")]
        [Required]
        [MinLength(5,ErrorMessage="Description should be atleast 5 characters")]
        [MaxLength(250,ErrorMessage="Chef's Name is exceeded the 250 characters limit")]
        public string description{get;set;}
        public DateTime created_at{get;set;} = DateTime.Now;
        public DateTime updated_at{get;set;} = DateTime.Now;


    }
}