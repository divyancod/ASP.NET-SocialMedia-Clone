using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    public interface IAnalyticsData
    {
        Dictionary<string, string> AdminDashboardData();
        Dictionary<string, int> MaleFemaleData();
        Dictionary<string, string> GetCountOfPostsByDate();
    }
}