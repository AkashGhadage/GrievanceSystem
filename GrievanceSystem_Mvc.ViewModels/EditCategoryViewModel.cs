using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class EditCategoryViewModel
    {
        public int CategoryID { get; set; }
        [Display(Name ="Category")]
        public string CategoryName { get; set; }
        
    }
}
