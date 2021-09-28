using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public class ReportRepository : IReportRepository
    {


        private readonly string _connectionString = Helper.GetConnectionString();


        public List<Grievance> GetDetailedReport(DateTime? startDate, DateTime? endDate)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                String sql = "spGetDetailedReport";
                List<Grievance> grievances = connection.Query<Grievance, Category, Subcategory, Status, Reply,User,User, Grievance>(sql,
                    (grievance, category, subcategory, status, reply,ruser,guser) =>
                    {
                        grievance.Category = category;
                        grievance.Subcategory = subcategory;
                        grievance.Status = status;
                        grievance.Reply = reply;
                        grievance.Ruser = ruser;
                        grievance.Guser = guser;
                        return grievance;
                    },
                    param: new { startdate= startDate,enddate=endDate },
                    splitOn: "CategoryID,SubcategoryID,StatusID,ReplyID,UserID,UserID", commandType: CommandType.StoredProcedure).ToList();

                return grievances;
            }
        }
    }
}
