using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    public class GlobalConstants
    {
        public const int LIKE = 0;
        public const int UNLIKE = 1;
    }
    public enum NotificationType
    {
        Liked,Commented,Followed
    }
}