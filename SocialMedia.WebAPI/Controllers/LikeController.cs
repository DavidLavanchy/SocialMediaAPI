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
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }

        public IHttpActionResult GetLikesByPostId(int id)
        {
            LikeService service = CreateLikeService();
            var likes = service.GetLikesByPostId(id);
            return Ok(likes);
        }

        public IHttpActionResult GetLikesByOwnerId(int id)
        {
            LikeService service = CreateLikeService();
            var likes = service.GetLikeById(id);
            return Ok(likes);
        }

        public IHttpActionResult CreateAlike(LikeCreateModel like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LikeService service = CreateLikeService();

            service.CreateLike(like);

            return Ok(like);
        }

        public IHttpActionResult UpdateALike(LikeEditModel like)
        {
            LikeService service = CreateLikeService();

            if (!service.UpdateALike(like))
                return BadRequest(ModelState);

            return Ok(ModelState);
        }

        public IHttpActionResult DeleteAlike(int id)
        {
            LikeService service = CreateLikeService();

            service.DeleteALike(id);

            if (!service.DeleteALike(id))
                return BadRequest("The id provided did not match a like within the database");

            return Ok();
        }

    }
}
