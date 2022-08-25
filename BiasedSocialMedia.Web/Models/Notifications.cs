using BiasedSocialMedia.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class Notifications
    {
        public int Id { get; set; }
        public NotificationType NType { get; set; }
        public int ForUser { get; set; }
        public int ByUserID { get; set; }
        public virtual Users ByUser { get; set; }
        public int NPostPostId { get; set; }
        public virtual Posts NPost { get; set; }
    }
}