using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class ProfileViewModel
    {
        public Users CurrentUser { get; set; }
        public List<Posts> UserPosts { get; set; }
    }
}