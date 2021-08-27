using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
    public class Comments
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public List<Comments> Replies { get; set; }
        


    }
}
