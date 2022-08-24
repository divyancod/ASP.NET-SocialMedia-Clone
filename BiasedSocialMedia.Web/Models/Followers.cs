using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class Followers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CurrentUserID { get; set; }
        public int FollowerUserId { get; set; }
        public virtual Users FollowerUser { get; set; }
    }
}