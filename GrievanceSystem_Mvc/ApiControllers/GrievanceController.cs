using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.Api_Controllers
{
    public class GrievanceController : ApiController
    {

        IGrievanceService gs;

        public GrievanceController(IGrievanceService gs)
        {
            this.gs = gs;
        }

        public int get()
        {

            //gs.GetGrievanceStat(); // here we get total grievance count 
            return 1;
        }



    }
}
