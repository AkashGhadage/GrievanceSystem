using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class EditGrievanceViewModel
    {
        public int GrievanceID { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Category_ID { get; set; }

        public int Subcategory_ID { get; set; }
    }
}
