using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class SubcategoryViewModel
    {
        [Required]
        public int SubcategoryID { get; set; }

        [Required]
        [Display(Name = "Subcategory")]
        public string SubcategoryName { get; set; }

        [Required]
        public int Category_ID { get; set; }
    }
}
