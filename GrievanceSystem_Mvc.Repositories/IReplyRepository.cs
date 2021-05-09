using GrievanceSystem_Mvc.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.Repositories
{
    public interface IReplyRepository
    {
        int InsertReply(Reply reply);

        int UpdateReply(Reply reply);

        int DeleteReply(int replyId);

        //List<Reply> GetReplyDetails(); // to fetch all Replies

        List<Reply> GetReplyByReplyId(int replyId); //to get ReplyDetails based on ReplyID

        List<Reply> GetReplyByGrievanceId(int grievanceID);// to  get ReplyDetails based on grievanceID
    }
}
