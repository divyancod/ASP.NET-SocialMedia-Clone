using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BiasedSocialMedia.Web.Utilities;

namespace BiasedSocialMedia.Web.Models
{
    public class LoginLogs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int LogID { get; set; }
        public string UserID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValueSql("GetDate()")]
        public DateTime LastLogin { get; set; }
        public string Remarks { get; set; }
    }
}