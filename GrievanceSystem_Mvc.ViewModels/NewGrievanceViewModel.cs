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
        public string Subject { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Subcategory { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = " * Field is required")]
        public int Category_ID { get; set; }

        [Required(ErrorMessage = " * Field is required")]
        public int Subcategory_ID { get; set; }

        public int Status_ID { get; set; }

        public int User_ID { get; set; }

    }
}
