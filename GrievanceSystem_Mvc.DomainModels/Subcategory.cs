using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrievanceSystem_Mvc.DomainModels
{
   public class Subcategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubcategoryID { get; set; }

        public string SubcategoryName { get; set; }
        public int Category_ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
