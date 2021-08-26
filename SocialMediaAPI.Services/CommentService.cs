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

        /*public bool CreateComment(CommentCreate model)
        {
            var entity =
                new CommentService()
                {
                    Id = _userId,
                    Text = model.Text
                }
        }*/
    }
}
