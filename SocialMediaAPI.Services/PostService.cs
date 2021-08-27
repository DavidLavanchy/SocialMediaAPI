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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreateModel model)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Title = model.Title,
                    Text = model.Text
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<PostListItemModel> GetPosts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new PostListItemModel
                        {
                            PostId = e.Id,
                            Text = e.Text,
                            Title = e.Title,
                            Likes = e.Likes,
                        });
                return query.ToArray();
            }
        }

        public PostDetailModel GetPostById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => id == Convert.ToInt32(_userId));
                return
                new PostDetailModel
                {
                    Title = entity.Title,
                    Text = entity.Text,
                    Likes = entity.Likes,
                };
            }
        }

        public bool UpdateAPost(PostEditModel model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == model.Id);

                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAPost(int postId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => postId == e.Id);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
