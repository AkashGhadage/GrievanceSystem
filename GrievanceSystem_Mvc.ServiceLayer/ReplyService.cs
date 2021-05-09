using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;
using GrievanceSystem_Mvc.DomainModels;
using GrievanceSystem_Mvc.Repositories;
using AutoMapper;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public class ReplyService : IReplyService
    {

        //repo reference
        readonly IReplyRepository rr;

        public ReplyService()
        {
            rr = new ReplyRepository();
        }

        public int InsertReply(NewReplyViewModel reply)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewReplyViewModel, Reply>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Reply r = mapper.Map<NewReplyViewModel, Reply>(reply);
            int rowAffeted = rr.InsertReply(r);
            return rowAffeted;
        }

        public int UpdateReply(EditReplyViewModel reply)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditReplyViewModel, Reply>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Reply r = mapper.Map<EditReplyViewModel, Reply>(reply);
            int rowAffeted = rr.UpdateReply(r);
            return rowAffeted;
        }

        public int DeleteReply(int replyId)
        {
            int rowAffeted = rr.DeleteReply(replyId);
            return rowAffeted;
        }

        public ReplyViewModel GetReplyByGrievanceId(int grievanceId)
        {
            Reply reply = rr.GetReplyByGrievanceId(grievanceId).SingleOrDefault();
            ReplyViewModel replyViewModel = null;
            if (reply != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Reply, ReplyViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                replyViewModel = mapper.Map<Reply, ReplyViewModel>(reply);
            }
            return replyViewModel;

        }

        public ReplyViewModel GetReplyByReplyId(int replyID)
        {
            Reply reply = rr.GetReplyByReplyId(replyID).SingleOrDefault();
            ReplyViewModel replyViewModel = null;
            if (reply != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Reply, ReplyViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                replyViewModel = mapper.Map<Reply, ReplyViewModel>(reply);
            }
            return replyViewModel;

        }

    }
}
