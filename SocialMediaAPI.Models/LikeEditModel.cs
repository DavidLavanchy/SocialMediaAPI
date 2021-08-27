﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class LikeEditModel
    {
        [Required]
        public int Id { get; set; }

        public int PostId { get; set; }
    }
}
