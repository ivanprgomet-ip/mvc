using System;
using System.Collections.Generic;
using System.Linq;
using MVCPhotoAlbums.Data.Models;
using System.IO;

namespace MVCPhotoAlbums.Data.Repositories
{
    public class UserRepository
    {
        //save in memory until we get a database
        public static List<UserModel> Users { get; private set; } = new List<UserModel>();

        public void AddUser(UserModel userToBeRegistered)
        {
            userToBeRegistered.Id = Guid.NewGuid();
            userToBeRegistered.DateRegistered = DateTime.Now;
            userToBeRegistered.Albums = new List<AlbumModel>();

            Users.Add(userToBeRegistered);
        }

        public UserModel ReturnUserById(Guid userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public UserModel ReturnUserLogin(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username== username && u.Password==password);
        }
    }
}