using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace DAL
{
    public class PostSQLContext : IPostContext
    {
        private readonly string _connectionString =@"Server=mssql.fhict.local;Database=dbi389621_forum;User Id=dbi389621_forum;Password=sjors;";

        public void AddPost(Post post)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spAddPost", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@UserId", post.UserId));
                command.Parameters.Add(new SqlParameter("@Created_At", post.DateTime));
                command.Parameters.Add(new SqlParameter("@Title", post.Title));
                command.Parameters.Add(new SqlParameter("@Body", post.Body));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Post> GetAllPosts()
        {
            var posts = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spGetAllPosts", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    posts.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        UserId = (int)reader["UserId"],
                        DateTime = (DateTime)reader["Created_At"],
                        Title = (string)reader["Title"],
                        Body = (string)reader["Body"]
                    });
                }
            }
            return posts;
        }

        public IEnumerable<Post> GetAllReplies(Post post)
        {
            var replies = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetAllReplies", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", post.Id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    replies.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        PostId = (int)reader["PostId"],
                        UserId = (int)reader["UserId"],
                        DateTime = (DateTime)reader["Created_At"],
                        Title = (string)reader["Title"],
                        Body = (string)reader["Body"]
                    });
                }
            }
            return replies;
        }
    }
}
