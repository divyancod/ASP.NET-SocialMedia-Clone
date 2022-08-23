using BiasedSocialMedia.Web.Models;
using BiasedSocialMedia.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiasedSocialMedia.Web.Utilities
{
    public class UserData : IUserData
    {
        private DataRepository dataRepository;
        public UserData(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;

        }
        public int addUser(string email, string password)
        {
            Users user = new Users();
            user.Email = email;
            user.Password = password;
            dataRepository.Users.Add(user);
            dataRepository.SaveChanges();
            return user.ID;
        }

        public Users getUser(int id)
        {
            return dataRepository.Users.Find(id);
        }

        public bool isUserExists(string email)
        {
            if(dataRepository.Users.FirstOrDefault(x=>x.Email==email)==null)
            {
                return false;
            }
            return true;
        }

        public bool isValidUserName(string username)
        {
            if(dataRepository.Users.FirstOrDefault(x => x.UserName == username)==null)
            {
                return true;
            }
            return false;
        }

        public Users LoginUser(string email, string password)
        {
            return dataRepository.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void updateData(string userid, string name, string phone, string gender, string username)
        {
            Users users = getUser(Convert.ToInt32(userid));
            users.Name = name;
            users.PhoneNumber = phone;
            users.Gender = gender[0];
            users.UserName = username;
            dataRepository.SaveChanges();
        }

        public void UpdateUserImage(string userid, int mediaID)
        {
            Users users = getUser(Convert.ToInt32(userid));
            users.ProfilePhotoID = mediaID;
            dataRepository.SaveChanges();
        }
    }
}
