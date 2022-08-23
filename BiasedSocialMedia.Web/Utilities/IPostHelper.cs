﻿using BiasedSocialMedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    public interface IPostHelper
    {
        Posts CreatePost(int userid,Posts postContent);
        List<Posts> GetAllPosts();
        Posts GetPostById(int id);
    }
}