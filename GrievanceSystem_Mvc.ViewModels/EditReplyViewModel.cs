using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class EditReplyViewModel
    {
        public int ReplyID { get; set; }

        public string ReplyMessage { get; set; }

        public int Grievance_ID { get; set; }

        public int User_ID { get; set; }
    }
}
