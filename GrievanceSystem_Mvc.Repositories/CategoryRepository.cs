using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connctionString = Helper.GetConnectionString();

        public int InsertCategory(Category category)
        {
            int affectedRow = 0;
            using (IDbConnection connection = new SqlConnection(_connctionString))
            {
                connection.Open();
                affectedRow = connection.Execute("spInsertCategory", new {CategoryName= category.CategoryName }, commandType: CommandType.StoredProcedure);
            }
            return affectedRow;
        }

        public int UpdateCategory(Category category)
        {
            int affectedRow = 0;
            DynamicParameters c = new DynamicParameters();
            c.Add("CategoryId",category.CategoryID);
            c.Add("CategoryName", category.CategoryName);

            using (IDbConnection connection = new SqlConnection(_connctionString))
            {
                connection.Open();
                affectedRow = connection.Execute("spUpdateCategory",param:c,commandType: CommandType.StoredProcedure);
            }
            return affectedRow;

        }
        
        public int DeleteCategory(int categoryId)
        {
            int affectedRow = 0;
            using (IDbConnection connection = new SqlConnection(_connctionString))
            {
                connection.Open();
                affectedRow = connection.Execute("spDeleteCategory", new { CategoryID = categoryId }, commandType: CommandType.StoredProcedure);
            }
            return affectedRow;
        }

        public List<Category> GetCategory()
        {
            using (IDbConnection connection = new SqlConnection(_connctionString))
            {
                connection.Open();
                return connection.Query<Category>("spGetCategory", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (IDbConnection connection = new SqlConnection(_connctionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Category>("spGetCategoryById",new { CategoryID = categoryId}, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
