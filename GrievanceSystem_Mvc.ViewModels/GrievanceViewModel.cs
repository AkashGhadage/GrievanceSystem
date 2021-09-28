using GrievanceSystem_Mvc.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class GrievanceViewModel
    {
        [Display(Name = "Id")]
        public int GrievanceID { get; set; }

        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        [Display(Name = "File")]
        public string file { get; set; }

        public string Status { get; set; }

        public CategoryViewModel category { get; set; }

        public SubcategoryViewModel subcategory { get; set; }

        public ReplyViewModel reply { get; set; }

        public User Guser { get; set; }

        public User Ruser { get; set; }

    }
}
