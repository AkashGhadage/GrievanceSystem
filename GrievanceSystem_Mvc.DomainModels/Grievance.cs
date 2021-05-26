using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.DomainModels
{
    public class Grievance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GrievanceID { get; set; }
        
        public DateTime ReportedDate { get; set; }
        
        public string Subject { get; set; }
        
        public string Description { get; set; }
        
        public string Image { get; set; }

        public int Category_ID { get; set; }

        public int Subcategory_ID { get; set; }

        public int Status_ID { get; set; }

        public int User_ID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Subcategory Subcategory { get; set; }

        public virtual Status Status { get; set; }

        public virtual Reply Reply { get; set; }

    }
}
