using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly string _connectionString = Helper.GetConnectionString();
        public int InsertReply(Reply reply)
        {
            DynamicParameters r = new DynamicParameters();
            r.Add("ReplyMessage", reply.ReplyMessage);
            r.Add("Grievance_ID", reply.Grievance_ID);
            r.Add("User_ID", reply.User_ID);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("spInserReply", r, commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateReply(Reply reply)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("spUpdateReply", new { reply.ReplyID, reply.ReplyMessage }, commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteReply(int replyId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("spDeleteReply", new { ReplyId = replyId }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Reply> GetReplyByGrievanceId(int grievanceId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Reply>("spGetReplyByGrievanceId", new { Grievance_ID = grievanceId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Reply> GetReplyByReplyId(int replyId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Reply>("spGetReplyByReplyId", new { replyId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
