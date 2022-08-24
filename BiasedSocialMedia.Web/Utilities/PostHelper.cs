using BiasedSocialMedia.Web.Migrations;
using BiasedSocialMedia.Web.Models;
using BiasedSocialMedia.Web.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        public Posts CreatePost(int userid, Posts post)
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

        public Dictionary<string,int> LikePost(int postId, int action, int userid)
        {
            if (!dataRepository.LikeUnlikeStatus.Where(x => x.PostId == postId && x.LikedById == userid).Any())
            {
                //LikeUnlikeStatus status = new LikeUnlikeStatus();
                //status.PostId = postId;
                //status.Status = action;// 0 - like ... 1-dislike
                //status.LikedById = userid;
                //dataRepository.LikeUnlikeStatus.Add(status);
                //dataRepository.SaveChanges();
                return CreateLikeStoredProcedure(postId, action, userid);

            }
            else
            {
                return null;
            }
        }

        public Dictionary<string, int> CreateLikeStoredProcedure(int postId, int action, int userid)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            int likeCount = 0;
            int unLikeCount = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=BiasedSMDB;Integrated Security=True"))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("UpdateLikeCount2", conn);
                    adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@postid", SqlDbType.Int).Value = postId;
                    adapter.SelectCommand.Parameters.AddWithValue("@status", SqlDbType.Int).Value = action;
                    adapter.SelectCommand.Parameters.AddWithValue("@userid", SqlDbType.Int).Value = userid;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "posts");

                    DataTable dt = ds.Tables["posts"];

                    foreach (DataRow row in dt.Rows)
                    {
                        likeCount = Convert.ToInt32(row["likecount"]);
                        unLikeCount = Convert.ToInt32(row["unlikecount"]);
                    }
                }
            }
            catch (Exception e)
            {

            }
            counts.Add("LIKE", likeCount);
            counts.Add("UNLIKE", unLikeCount);
            return counts;
        }
    }
}