using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class LoginLogs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid LogID { get; set; }
        public string UserGuid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastLogin { get; set; }
    }
}