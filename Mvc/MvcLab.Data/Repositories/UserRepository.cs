using System;
using System.Collections.Generic;
using System.Linq;
using MvcLab.Data.Models;
using System.IO;

namespace MvcLab.Data.Repositories
{
    /// <summary>
    /// the repository classes only hade direct contact with the 
    /// entity models of the database, and not the viewmodels that 
    /// the controllers have their main comunication with.
    /// 
    /// The repositories do logical crud operations against the database
    /// context.
    /// </summary>
    public class UserRepository
    {

        /// <summary>
        /// register a new user. Adds user to the database.
        /// </summary>
        /// <param name="userToBeRegistered"></param>
        public void Add(UserEntity userToBeRegistered)
        {
            userToBeRegistered.UserId = Guid.NewGuid();

            userToBeRegistered.DateRegistered = DateTime.Now;

            userToBeRegistered.Albums = new List<AlbumEntity>();

            using (MvcLabContext _context = new MvcLabContext())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// return a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserEntity GetUser(Guid userId)
        {
            using (MvcLabContext _context = new MvcLabContext())
            {
                return _context.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }

        public UserEntity RetrieveLoggedInUser(string username, string password)
        {
            using (MvcLabContext _context = new MvcLabContext())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserEntity> RetrieveAll()
        {
            List<UserEntity> users = new List<UserEntity>();

            using (MvcLabContext _context = new MvcLabContext())
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