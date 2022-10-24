using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BiasedSocialMedia.Web.Utilities;

namespace BiasedSocialMedia.Web.Models
{
    public class Posts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int PostID { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public string PostContent { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        public Boolean isDeleted { get; set; }
        public int LikeCount { get; set; }
        public int UnLikeCount { get; set; }
        public int CommentCount { get; set; }
        public string GetPostTimeInString()
        {
            return CreatedAt.ToString("dddd, dd MMMM yyyy");
        }
        public virtual ICollection<PostMediaMap> PostMediaMaps { get; set; }
        [NotMapped]
        public bool IsLikedByCurrentUser { get; set; }
    }
}