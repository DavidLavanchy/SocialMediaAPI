using SocialMedia.Data;
using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreateModel like)
        {
            var entity =
                new Like()
                {
                    Id = like.Id,
                    PostId = like.PostId,
                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<LikeListItemModel> GetLikesByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Where(e => id == e.PostId)
                    .Select(
                        e =>
                        new LikeListItemModel
                        {
                            Id = e.Id,
                            PostId = e.PostId,
                        });
                return query.ToArray();
            }
        }

        public IEnumerable<LikeListItemModel> GetLikeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Where(e => id == e.Id)
                    .Select(
                        e =>
                        new LikeListItemModel
                        {
                            Id = e.Id,
                            PostId = e.PostId,
                        });
                return query.ToArray();
            }

        }
        public bool UpdateALike(LikeEditModel like)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                 ctx
                 .Likes
                 .Single(e => like.Id == like.Id);

                entity.Id = like.Id;
                entity.PostId = like.PostId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteALike(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                 ctx
                 .Likes
                 .Single(e => id == e.Id);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
