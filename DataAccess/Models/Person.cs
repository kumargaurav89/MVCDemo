using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Person
    {
        public int BusinessEntityID { get; set; }

        [Display(Name = "Title")]
        //[Required(ErrorMessage ="Title is required.")]
       // [MaxLength(12, ErrorMessage = "Title should be between 8 - 12 char long.")]
       // [MinLength(8, ErrorMessage = "Title should be between 8 - 12 char long.")]
        public string Title { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
    }
}