using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    [Table("MediaInfo")]
    public class ImageUploadModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int MediaID { get; set; }
        public string FileName { get; set; }
        public string MediaURL{ get; set; }
        public Byte[] Data { get; set; }
    }
}