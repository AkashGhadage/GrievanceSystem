using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public class GrievanceRepository : IGrievanceRepository
    {
        private readonly string _connectionString = Helper.GetConnectionString();

        // from here we can unbind our data 
        //TODO:DONE t1
        public int InsertGrievanceDetails(Grievance grievance)
        {
            int rowAffected = 0;
            var g = new DynamicParameters();
            g.Add("Subject", grievance.Subject);
            g.Add("Description", grievance.Description);
            g.Add("Image", grievance.Image);
            g.Add("Category_ID", grievance.Category_ID);
            g.Add("Subcategory_ID", grievance.Subcategory_ID);
            g.Add("Status_ID", grievance.Status_ID);
            g.Add("User_ID", grievance.User_ID);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                rowAffected = connection.Execute("spInsertGrievanceDetails", param: g, commandType: CommandType.StoredProcedure);
            }
            return rowAffected;
        }

        //TODO:DONE t1

        public int UpdateGrievanceDetails(Grievance grievance)
        {
            int rowAffected = 0;
            var g = new DynamicParameters();
            g.Add("GrievanceID", grievance.GrievanceID);
            g.Add("Subject", grievance.Subject);
            g.Add("Description", grievance.Description);
            //g.Add("Image", grievance.Image);
            g.Add("Category_ID", grievance.Category_ID);
            g.Add("Subcategory_ID", grievance.Subcategory_ID);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                rowAffected = connection.Execute("spUpdateGrievanceDetails", param: g, commandType: CommandType.StoredProcedure);
            }
            return rowAffected;
        }

        public int DeleteGrievance(int grievanceId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("spDeleteGrievance", param: new { GrievanceID = grievanceId }, commandType: CommandType.StoredProcedure);
            }

        }

        //TODO:DONE t1
        public List<Grievance> GetGrievance()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetGrievance";
                List<Grievance> grievances = connection.Query<Grievance, Category, Subcategory, Status, Grievance>(sql,
                    (grievance, category, subcategory, status) =>
                    {
                        grievance.Category = category;
                        grievance.Subcategory = subcategory;
                        grievance.Status = status;
                        return grievance;
                    },
                    splitOn: "CategoryID,SubcategoryID,StatusID", commandType: CommandType.StoredProcedure).ToList();

                return grievances;
            }
        }

        //TODO:DONE t1
        public List<Grievance> GetGrievanceByGrievanceId(int grievanceId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetGrievanceByGrievanceID";
                List<Grievance> grievances = connection.Query<Grievance, Category, Subcategory, Status, Grievance>(sql,
                    (grievance, category, subcategory, status) =>
                    {
                        grievance.Category = category;
                        grievance.Subcategory = subcategory;
                        grievance.Status = status;
                      
                        return grievance;
                    },
                    param: new { id = grievanceId },
                    splitOn: "CategoryID,SubcategoryID,StatusID", commandType: CommandType.StoredProcedure).ToList();
                return grievances;
            };
        }

        //TODO:DONE t1
        public List<Grievance> GetGrievanceByUserId(int userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetGrievanceByUserId";
                List<Grievance> grievances = connection.Query<Grievance, Category, Subcategory, Status, Grievance>(sql,
                    (grievance, category, subcategory, status) =>
                    {
                        grievance.Category = category;
                        grievance.Subcategory = subcategory;
                        grievance.Status = status;
                        return grievance;
                    },
                    param: new { UserID = userId },
                    splitOn: "CategoryID,SubcategoryID,StatusID", commandType: CommandType.StoredProcedure).ToList();
                return grievances;
            }
        }
    }
}
