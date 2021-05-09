using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class GrievanceStatViewModel
    {
        public int GrievanceReceived { get; set; }

        public int GrievanceRedressed { get; set; }

        public int GrievanceInProgress { get; set; }
    }
}
