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
            using (PhotoExplorerDbContext _context = new PhotoExplorerDbContext())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserModel GetUser(string userid)
        {
            using (PhotoExplorerDbContext _context = new PhotoExplorerDbContext())
            {
                UserModel user = _context.Users
                    .Where(u => u.Id == userid)
                    .Include(u => u.Albums
                        .Select(p => p.Photos
                        .Select(c => c.Comments))) //neccessary to include the albums 
                    .FirstOrDefault();
                return user;
            }
        }

        public UserModel RetrieveLoggedInUser(string username, string password)
        {
            using (PhotoExplorerDbContext _context = new PhotoExplorerDbContext())
            {
                return _context.Users
                    .FirstOrDefault(u => u.UserName == username &&
                    u.PasswordHash == password);
            }

        }

        public List<UserModel> RetrieveAll()
        {
            List<UserModel> users = new List<UserModel>();

            using (PhotoExplorerDbContext _context = new PhotoExplorerDbContext())
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