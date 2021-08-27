using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class LikeDetailModel
    {
        public int PostId { get; set; }
        public int Id { get; set; }
    }
}
