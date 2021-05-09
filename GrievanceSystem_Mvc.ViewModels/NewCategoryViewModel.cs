using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class NewCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
