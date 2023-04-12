using Dapper;
using JWTAuth.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JWTAuth.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
        public void CreateUser(User user)
        {
            var sql = @"Insert Into [dbo].[User] values(@UserName,@Password,@Email)";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new {user.UserName, user.Password,user.Email});
            }
        }
    }
}