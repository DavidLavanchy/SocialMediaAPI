using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class LikeListItemModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        public int NumberOfLikesOnPost { get; set; }
    }
}
