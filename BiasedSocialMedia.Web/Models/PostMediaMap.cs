using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class PostMediaMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PostsPostID { get; set; }
        public int PostMediaId { get; set; }
    }
}