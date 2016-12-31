using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Entity;
using PhotoExplorer.Data.Entities;

namespace PhotoExplorer.Data.Repositories
{
    public class UserRepository
    {
        public void Add(UserEntityModel userToBeRegistered)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserEntityModel GetUser(int IserModelId)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
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
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserEntityModel> RetrieveAll()
        {
            List<UserEntityModel> users = new List<UserEntityModel>();

            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
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