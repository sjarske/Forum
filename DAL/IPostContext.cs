using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPostContext
    {
        void AddPost(Post post);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetAllReplies(Post post);

    }
}
