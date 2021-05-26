using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class ReplyViewModel
    {
        public int ReplyID { get; set; }

        [Display(Name = "Reply Date")]
        public DateTime ReplyDate { get; set; }


        [Display(Name = "Reply")]
        public string ReplyMessage { get; set; }

        public int Grievance_ID { get; set; }

        public int User_ID { get; set; }

    }
}
