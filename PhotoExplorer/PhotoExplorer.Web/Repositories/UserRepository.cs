using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Entity;
using PhotoExplorer.Web.Entities;

namespace MvcLab.Web.Repositories
{
    public class UserRepository
    {
        public void Add(UserEntityModel userToBeRegistered)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserEntityModel GetUser(int IserModelId)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                UserEntityModel user = _context.Users
                    .Where(u => u.Id == IserModelId)
                    .Include(u => u.Albums
                        .Select(p => p.Photos
                        .Select(c => c.Comments))) //neccessary to include the albums 
                    .FirstOrDefault();
                return user;
            }
        }

        public UserEntityModel RetrieveLoggedInUser(string username, string password)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserEntityModel> RetrieveAll()
        {
            List<UserEntityModel> users = new List<UserEntityModel>();

            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                List<UserEntityModel> userEntitiesFromDB = _context.Users.ToList();

                foreach (var user in userEntitiesFromDB)
                {
                    users.Add(user);
                }

                return users;
            }

        }
    }
}