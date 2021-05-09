using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = Helper.GetConnectionString();

        public int InsertUser(User user)
        {
            int affectedRows = 0;

            var Email = new DynamicParameters();
            Email.Add("EmailAddress", user.Email.EmailAddress);
            Email.Add("Email_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //by executing command 1 we will get id of last inserted record 
                        //and we store that id in user. email id and for role we get value of role from controller or frm ui 

                        connection.Execute("spInsertEmailAddress", param: Email, commandType: CommandType.StoredProcedure, transaction: transaction);
                        user.Email_ID = Email.Get<int>("Email_ID");


                        var u = new DynamicParameters();
                        u.Add("FirstName", user.FirstName);
                        u.Add("MiddleName", user.MiddleName);
                        u.Add("LastName", user.LastName);
                        u.Add("MobileNumber", user.MobileNumber);
                        u.Add("Password", user.Password);
                        u.Add("PasswordHash", user.PasswordHash);
                        //u.Add("DateCreated", user.DateCreated);
                        u.Add("Role_ID", user.Role_ID);
                        u.Add("Email_ID", user.Email_ID);

                        affectedRows = connection.Execute("spInsertUser", param: u, commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        //handle exception or throw 
                    }
                }
                return affectedRows;
            }
        }

        public int UpdateUserDetails(User user)
        {
            int affectedRows = 0;

            var u = new DynamicParameters();
            u.Add("UserID", user.UserId);
            u.Add("FirstName", user.FirstName);
            u.Add("MiddleName", user.MiddleName);
            u.Add("LastName", user.LastName);
            u.Add("MobileNumber", user.MobileNumber);
            u.Add("EmailAddress", user.Email.EmailAddress);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                affectedRows = connection.Execute("spUpdateUserDetails", param: u, commandType: CommandType.StoredProcedure);
            }
            return affectedRows;

        }

        public int UpdateUserPassword(User user)
        {
            int affectedRows = 0;

            var u = new DynamicParameters();
            u.Add("UserID", user.UserId);
            u.Add("Password", user.Password);
            u.Add("PasswordHash", user.PasswordHash);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                affectedRows = connection.Execute("spUpdateUserPassword", param: u, commandType: CommandType.StoredProcedure);
            }
            return affectedRows;
        }

        public int DeleteUser(int userId)
        {
            int affectedRows = 0;
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                affectedRows = connection.Execute("spDeleteUser", new { userId = userId }, commandType: CommandType.StoredProcedure);
            }
            return affectedRows;
        }

        public List<User> GetUser()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetUsers";
                List<User> users = connection.Query<User, Email, Role, User>(sql,
                    (user, email, role) => { user.Email = email; user.Role = role; return user; },
                    splitOn: "EmailID,RoleID", commandType: CommandType.StoredProcedure).ToList();
                return users;
            }
        }

        public List<User> GetUserByEmail(string emailAddress)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetUserByEmail";
                List<User> users = connection.Query<User, Email, Role, User>(sql,
                    (user, email, role) => { user.Email = email; user.Role = role; return user; },
                    new { EmailAddress = emailAddress },
                    splitOn: "EmailID,RoleID", commandType: CommandType.StoredProcedure).ToList();
                return users;
            }
        }

        public List<User> GetUserByEmailAndPassword(string emailAddress, string password)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetUserByEmailAndPassword";
                List<User> users = connection.Query<User, Email, Role, User>(sql,
                    (user, email, role) => { user.Email = email; user.Role = role; return user; },
                    param: new { emailAddress, password },
                    splitOn: "EmailID,RoleID", commandType: CommandType.StoredProcedure).ToList();
                return users;
            };
        }

        public List<User> GetUserByUserID(int userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetUserByUserID";
                List<User> users = connection.Query<User, Email, Role, User>(sql,
                    (user, email, role) => { user.Email = email; user.Role = role; return user; }, new { UserID = userId },
                    splitOn: "EmailID,RoleID", commandType: CommandType.StoredProcedure).ToList();
                return users;
            }
        }

        public List<User> GetUsersByRoleId(int roleId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetUserByRoleId";
                List<User> users = connection.Query<User, Email, Role, User>(sql,
                  (user, email, role) => { user.Email = email; user.Role = role; return user; }, new { RoleID = roleId },
                  splitOn: "EmailID,RoleID", commandType: CommandType.StoredProcedure).ToList();
                return users;
            }
        }

        public string[] GetRolesForUser(string username)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "spGetRolesForUserByUserName";
                return connection.Query<string>(sql, param: new { UserName = username }, commandType: CommandType.StoredProcedure).ToArray();
            }
        }
    }
}
