using System;
using System.Collections.Generic;
using System.Linq;
using MvcLab.Data.Models;
using System.IO;
using System.Data.Entity;

namespace MvcLab.Data.Repositories
{
    public class UserRepository
    {
        public void Add(UserEntity userToBeRegistered)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserEntity GetUser(int IserModelId)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                UserEntity user = _context.Users
                    .Where(u => u.UserEntityId == IserModelId)
                    .Include(u => u.Albums
                        .Select(p => p.Photos
                        .Select(c => c.Comments))) //neccessary to include the albums 
                    .FirstOrDefault();
                return user;
            }
        }

        public UserEntity RetrieveLoggedInUser(string username, string password)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserEntity> RetrieveAll()
        {
            List<UserEntity> users = new List<UserEntity>();

            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                List<UserEntity> userEntitiesFromDB = _context.Users.ToList();

                foreach (var user in userEntitiesFromDB)
                {
                    users.Add(user);
                }

                return users;
            }

        }
    }
}