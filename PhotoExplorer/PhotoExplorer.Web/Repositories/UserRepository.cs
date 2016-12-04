using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Entity;
using PhotoExplorer.Web.Models;

namespace MvcLab.Web.Repositories
{
    public class UserRepository
    {
        public void Add(UserModel userToBeRegistered)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserModel GetUser(int IserModelId)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                UserModel user = _context.Users
                    .Where(u => u.Id == IserModelId)
                    .Include(u => u.Albums
                        .Select(p => p.Photos
                        .Select(c => c.Comments))) //neccessary to include the albums 
                    .FirstOrDefault();
                return user;
            }
        }

        public UserModel RetrieveLoggedInUser(string username, string password)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserModel> RetrieveAll()
        {
            List<UserModel> users = new List<UserModel>();

            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                List<UserModel> userEntitiesFromDB = _context.Users.ToList();

                foreach (var user in userEntitiesFromDB)
                {
                    users.Add(user);
                }

                return users;
            }

        }
    }
}