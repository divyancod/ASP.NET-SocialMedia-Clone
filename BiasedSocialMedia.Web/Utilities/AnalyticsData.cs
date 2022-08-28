using BiasedSocialMedia.Web.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    public class AnalyticsData : IAnalyticsData
    {
        private DataRepository dataRepository;
        public AnalyticsData(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public Dictionary<string, string> AdminDashboardData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("user",dataRepository.Users.Count().ToString());
            result.Add("posts",dataRepository.Posts.Count().ToString());
            result.Add("notification",dataRepository.Notification.Count().ToString());
            return result;
        }

        public Dictionary<string, string> GetCountOfPostsByDate()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                string query = "  select top 5 CONVERT(date,CreatedAt),count(*) from posts group by CONVERT(date,CreatedAt) order by CONVERT(date,CreatedAt) asc";
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=BiasedSMDB;Integrated Security=True"))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        DataTable table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                result.Add(row[0].ToString(), row[1].ToString());
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public Dictionary<string, int> MaleFemaleData()
        {
            int male = 0;
            int female = 0;
            Dictionary<string, int> result = new Dictionary<string, int>();
            male = dataRepository.Users.Where(x => x.Gender == "M").Count();
            female = dataRepository.Users.Where(x => x.Gender == "F").Count();
            result.Add("MALE", male);
            result.Add("FEMALE", female);
            return result;
        }
    }
}