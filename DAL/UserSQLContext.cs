using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserSQLContext : IUserContext
    {
        private readonly string _connectionString =
    @"Server=mssql.fhict.local;Database=dbi389621_forum;User Id=dbi389621_forum;Password=sjors;";

        public void Register(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spRegister", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.Parameters.Add(new SqlParameter("@Email", user.Email));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool Login(User user)
        {
            bool loginSuccesfull = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    loginSuccesfull = true;
                }
                reader.Close();
            }
            return loginSuccesfull;
        }

        public List<string> GetUserRoles(User user)
        {
            var roles = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetUserRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(reader["AuthorizationName"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return roles;
        }

        public User GetUser(User user)
        {
            User _user = new User();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _user.UserId = (int)reader["UserId"];
                    _user.Username = (string)reader["Username"];
                    _user.Email = (string)reader["Email"];
                }
                reader.Close();
            }
            return _user;
        }
    }
}
