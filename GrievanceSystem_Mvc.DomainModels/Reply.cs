using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrievanceSystem_Mvc.DomainModels
{
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplyID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ReplyDate { get; set; }

        public string ReplyMessage { get; set; }

        public int Grievance_ID { get; set; }

        public int User_ID { get; set; }

        //[ForeignKey("User_ID")]
        //public virtual User User { get; set; }
    }
}
