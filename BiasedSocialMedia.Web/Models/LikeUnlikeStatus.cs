using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class LikeUnlikeStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //Not doing mapping as mapping is causing cascade issue { I need to learn that}
        public int PostId { get; set; }
        public int LikedById { get; set; }
        public virtual Users LikedBy { get; set; }
        public int Status { get; set; }
    }
}