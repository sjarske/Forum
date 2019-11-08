using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PostLogic
    {
        private readonly IPostContext _context;

        public PostLogic()
        {
            _context = new PostSQLContext();
        }

        public void AddPost(Post post)
        {
            _context.AddPost(post);
        }

        public IEnumerable<Post> PostOverview()
        {
            return _context.GetAllPosts();
        }

        public IEnumerable<Post> ReplyOverview(Post post)
        {
            return _context.GetAllReplies(post);
        }
    }
}
