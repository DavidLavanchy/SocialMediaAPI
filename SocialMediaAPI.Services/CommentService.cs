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
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comments()
                {
                    
                    Text = model.Text,
                    AuthorId = model.AuthorId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new CommentItem
                                {
                                    AuthorId = e.AuthorId,
                                    Text = e.Text
                                }
                               );
                return query.ToArray();
            }
        }
    }

}
