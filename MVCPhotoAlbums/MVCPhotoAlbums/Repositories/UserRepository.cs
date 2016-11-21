using MVCPhotoAlbums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPhotoAlbums.Repositories
{
    public class UserRepository
    {
        public static List<UserModel> _users = new List<UserModel>();

        public void AddUser(UserModel userToBeRegistered)
        {
            userToBeRegistered.Id = Guid.NewGuid();
            userToBeRegistered.DateRegistered = DateTime.Now;

            _users.Add(userToBeRegistered);
        }
        public UserModel ReturnUser(Guid userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }
    }
}