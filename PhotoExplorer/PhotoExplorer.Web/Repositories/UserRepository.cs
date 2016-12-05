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
        public void Add(UserViewModel userToBeRegistered)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserViewModel GetUser(int IserModelId)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                UserViewModel user = _context.Users
                    .Where(u => u.Id == IserModelId)
                    .Include(u => u.Albums
                        .Select(p => p.Photos
                        .Select(c => c.Comments))) //neccessary to include the albums 
                    .FirstOrDefault();
                return user;
            }
        }

        public UserViewModel RetrieveLoggedInUser(string username, string password)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserViewModel> RetrieveAll()
        {
            List<UserViewModel> users = new List<UserViewModel>();

            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                List<UserViewModel> userEntitiesFromDB = _context.Users.ToList();

                foreach (var user in userEntitiesFromDB)
                {
                    users.Add(user);
                }

                return users;
            }

        }
    }
}