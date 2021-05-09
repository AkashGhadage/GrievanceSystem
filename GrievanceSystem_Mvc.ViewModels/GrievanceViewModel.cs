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

        public string Image { get; set; }


        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Status { get; set; }


        public string Category_ID { get; set; }

        public string Subcategory_ID { get; set; }


        [Display(Name = "Reply")]
        public string ReplyMessage { get; set; }

        [Display(Name = "Reply Date")]
        public DateTime ReplyDate { get; set; }

        //public string ReplyMessage { get; set; }

        //here we need reply class details
    }
}
