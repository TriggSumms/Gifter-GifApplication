using Gifter.Models;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        void Delete(int id);
        List<Post> GetAll();
        Post GetById(int id);
        void Update(Post post);

        List<Post> GetAllWithComments();

        //Post GetPostByIdWithComments(int id);
    }
}