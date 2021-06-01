using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class NewGrievanceViewModel
    {

        [Required]
        public string subject { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string category { get; set; }

        [Required]
        [Display(Name = "Subcategory")]
        public string subcategory { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        public string file { get; set; }

        [Required(ErrorMessage = " * Field is required")]
        public int category_id { get; set; }

        [Required(ErrorMessage = " * Field is required")]
        public int subcategory_id { get; set; }

        public int status_id { get; set; }

        public int user_id { get; set; }

    }
}
