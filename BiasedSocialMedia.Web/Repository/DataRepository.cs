using BiasedSocialMedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Repository
{
    public class DataRepository:DbContext
    {
        public DataRepository() : base("BiasedSocialMediaConnectionString")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<LoginLogs> LoginLogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ImageUploadModel> MediaInfo { get; set; }
        public DbSet<Posts> Posts { get; set; }
    }
}