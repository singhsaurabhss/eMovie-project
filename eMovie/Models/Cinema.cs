using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Logo")]
        [Required(ErrorMessage ="LogoURL is required")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        //Model Relationships
        public List<Movie> Movies { get; set; }
     
    }
}
