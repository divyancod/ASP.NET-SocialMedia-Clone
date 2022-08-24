using BiasedSocialMedia.Web.Models;
using BiasedSocialMedia.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    public class PostHelper : IPostHelper
    {
        private DataRepository dataRepository;
        private readonly int PageItems = 15;
        public PostHelper(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;

        }
        public Posts CreatePost(int userid,Posts post)
        {
            Posts newPosts = dataRepository.Posts.Create();
            newPosts.UserId = userid;
            newPosts.PostContent = post.PostContent;
            dataRepository.Posts.Add(newPosts);
            dataRepository.SaveChanges();
            return newPosts;
        }

        public List<Posts> GetAllPostByPage(int page)
        {
            return dataRepository.Posts.OrderByDescending(x => x.PostID).Skip(page * PageItems).Take(PageItems).ToList();
        }

        public List<Posts> GetAllPosts()
        {
            return dataRepository.Posts.OrderByDescending(x => x.PostID).Take(PageItems).ToList();
        }

        public Posts GetPostById(int id)
        {
            return dataRepository.Posts.Find(id);
        }
    }
}