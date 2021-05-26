using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class NewReplyViewModel
    {

        [Required]
        [Display(Name ="Reply")]
        public string ReplyMessage { get; set; }

        [Required]
        public int Grievance_ID { get; set; }
       
        [Required]
        public int User_ID { get; set; }



    }
}
