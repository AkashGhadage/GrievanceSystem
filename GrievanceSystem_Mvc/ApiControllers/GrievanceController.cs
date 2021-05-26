using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;
using Newtonsoft.Json;

namespace GrievanceSystem_Mvc.Api_Controllers
{
    public class GrievanceController : ApiController
    {

        IGrievanceService gs;
        IReplyService rs;

        public GrievanceController(IGrievanceService gs, IReplyService rs)
        {
            this.gs = gs;
            this.rs = rs;
        }

        public string getReply(int grievanceId)
        {

            ReplyViewModel reply= rs.GetReplyByGrievanceId(grievanceId);
            return JsonConvert.SerializeObject(reply);
        }



    }
}
