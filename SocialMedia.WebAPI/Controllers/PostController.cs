using Microsoft.AspNet.Identity;
using SocialMediaAPI.Models;
using SocialMediaAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

        private IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        private IHttpActionResult Post(PostCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(model))
                return InternalServerError();

            return Ok();
        }

        private IHttpActionResult GetPostById(int id)
        {
            var service = CreatePostService();

            var post = service.GetPostById(id);

            if (service.GetPostById(id) == null)
                return BadRequest("The Id provided did not match a post within the database");

            return Ok(post);
        }

        private IHttpActionResult UpdatePost(PostEditModel updatedPost)
        {
            var service = CreatePostService();

            if (!service.UpdateAPost(updatedPost))
                return BadRequest("Please make sure the updated post has all required fields");

            service.UpdateAPost(updatedPost);
            return Ok(updatedPost);
        }

        private IHttpActionResult Deletepost(int id)
        {
            var service = CreatePostService();

            if (!service.DeleteAPost(id))
                return BadRequest();

            service.DeleteAPost(id);
            return Ok("Post successfully deleted.");
        }
    }
}
