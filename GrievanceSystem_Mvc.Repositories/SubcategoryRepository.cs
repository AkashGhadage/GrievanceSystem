using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly string _connectionstring = Helper.GetConnectionString();

        public int InsertSubcategory(Subcategory subcategory)
        {

            DynamicParameters sc = new DynamicParameters();
            sc.Add("Category_ID", subcategory.Category_ID);
            sc.Add("SubcategoryName", subcategory.SubcategoryName);
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {

                return connection.Execute("spInsertSubcategory", param: sc, commandType: CommandType.StoredProcedure); ;

            }

        }

        public int UpdateSubcategory(Subcategory subcategory)
        {

            DynamicParameters sc = new DynamicParameters();
            sc.Add("SubcategoryID", subcategory.SubcategoryID);
            sc.Add("Category_ID", subcategory.Category_ID);
            sc.Add("SubcategoryName", subcategory.SubcategoryName);
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {

                return connection.Execute("spUpdateSubcategory", param: sc, commandType: CommandType.StoredProcedure); ;

            }
        }

        public int DeleteSubcategory(int subcategoryId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {

                return connection.Execute("spDeleteSubcategory", new { SubcategoryID = subcategoryId }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Subcategory> GetSubcategory()
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {

                return connection.Query<Subcategory>("spGetSubcategory", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Subcategory> GetSubcategoryByCategoryId(int categoryId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {

                return connection.Query<Subcategory>("spGetSubcategoryByCategoryId", new { category_ID = categoryId}, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Subcategory GetSubcategoryById(int subcategoryId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {

                return connection.QuerySingleOrDefault<Subcategory>("spGetSubategoryById", new { SubcategoryID = subcategoryId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
