using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class PostDetailModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public List<Like> Likes { get; set; }
    }
}
