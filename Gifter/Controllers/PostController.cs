using System;
using Microsoft.AspNetCore.Mvc;
using Gifter.Repositories;
using Gifter.Models;

namespace Gifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        //SECONDARY METHOD...thats not "smart"
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var posts = _postRepository.GetAll();

        //    foreach (var post in posts)
        //    {
        //        post.UserProfile = _userProfileRepository.GetById(post.UserProfileId);
        //    }

        //    return Ok(posts);
        //}

        [HttpGet("GetWithComments")]
        public IActionResult GetWithComments()
        {
            var posts = _postRepository.GetAllWithComments();
            return Ok(posts);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postRepository.GetById(id);
            //var post = _postRepository.GetPostByIdWithComments(id);
            //Need to find place to integrate this specific call...
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(Post post)
        {
            _postRepository.Add(post);
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return NoContent();
        }

        //SEARCH CONTROLLER
        [HttpGet("search")]
        public IActionResult Search(string q, bool sortDesc)
        {
            return Ok(_postRepository.Search(q, sortDesc));
        }

        //Exercise 3.
        //SEARCH CONTROLLER
        [HttpGet("hottest")]
        public IActionResult Search2(DateTime since, bool sortDesc)
        {
            return Ok(_postRepository.Search2(since, sortDesc));
        }

    }
}
