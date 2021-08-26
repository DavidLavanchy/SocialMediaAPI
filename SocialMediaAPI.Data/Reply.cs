using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
  public class Reply
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(comment))]
        public int CommentID { get; set; }
        public virtual Comment comment { get; set; }
        public string text { get; set; }
        public Guid AuthorID { get; set; }
    }
}
