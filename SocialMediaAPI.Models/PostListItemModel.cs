using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class PostListItemModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Like> Likes { get; set; }
    }
}
