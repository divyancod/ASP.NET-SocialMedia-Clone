using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoURL { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}