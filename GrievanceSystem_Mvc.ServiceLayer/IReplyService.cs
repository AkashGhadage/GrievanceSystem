using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;
namespace GrievanceSystem_Mvc.ServiceLayer
{
    public interface IReplyService
    {
        int InsertReply(NewReplyViewModel reply);

        int UpdateReply(EditReplyViewModel reply);

        int DeleteReply(int replyId);

        //List<ReplyViewModel> GetReplyDetails(); // to fetch all Replies but may be we dont need all replies 

        ReplyViewModel GetReplyByReplyId(int replyId); //to get ReplyDetails based on ReplyID

        ReplyViewModel GetReplyByGrievanceId(int grievanceId); //to get ReplyDetails based on gid


    }
}
