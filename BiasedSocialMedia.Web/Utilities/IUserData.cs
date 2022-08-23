using BiasedSocialMedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiasedSocialMedia.Web.Utilities
{
    public interface IUserData
    {
        Users getUser(int id);
        int addUser(string email, string password);
        void updateData(string userid, string name, string phone, string gender, string username);
        void UpdateUserImage(string userid, int mediaID);
        Users LoginUser(string email, string password);
    }
}
