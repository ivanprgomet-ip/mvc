using System;
using System.Collections.Generic;
using System.Linq;
using MvcLab.Data.Models;

namespace MvcLab.Data.Repositories
{
    public class UserRepository
    {
        //save in memory until we move to a database
        public static IList<UserModel> Users { get; private set; } = new List<UserModel>();

        /// <summary>
        /// if there are NO users in the temporary memory,
        /// then we create some temporary data to test application with
        /// </summary>
        public UserRepository()
        {
            if (!Users.Any())
            {
                SetupTemporaryData();
            }
        }

        private void SetupTemporaryData()
        {
            //create some default users
            UserModel u1 = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "Ivan",
                Lastname = "Prgomet",
                Country = "Sweden",
                City = "Lund",
                Street = "lundstreet 2",
                Email = "ip@gmail.com",
                Phone = "0735709868",
                Username = "ivanprgomet",
                Password = "ivan123",
                DateRegistered = DateTime.Now,

                Albums = new List<AlbumModel>(),
            };

            UserModel u2 = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "Lea",
                Lastname = "Winchester",
                Country = "England",
                City = "London",
                Street = "Grape Street",
                Email = "leawinchester@gmail.com",
                Phone = "92345873294",
                Username = "leawinchester",
                Password = "lealea",
                DateRegistered = DateTime.Now,

                Albums = new List<AlbumModel>(),
            };

            UserModel u3 = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "Scott",
                Lastname = "Ferryson",
                Country = "Australia",
                City = "Sydney",
                Street = "Kangaroo Alley 8",
                Email = "ImScott@gmail.com",
                Phone = "3940857",
                Username = "scottferryson",
                Password = "scott123",
                DateRegistered = DateTime.Now,

                Albums = new List<AlbumModel>(),
            };

            //add the users to the temp memory
            Users.Add(u1);
            Users.Add(u2);
            Users.Add(u3);

            //add folders for all these users

            //add some default albums for the users 

            //populate the albums with some default photos
        }

        public void Add(UserModel userToBeRegistered)
        {
            userToBeRegistered.Id = Guid.NewGuid();

            userToBeRegistered.DateRegistered = DateTime.Now;

            userToBeRegistered.Albums = new List<AlbumModel>();

            Users.Add(userToBeRegistered);
        }

        /// <summary>
        /// return a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel Return(Guid userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public UserModel ReturnUserLogin(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username== username && u.Password==password);
        }
    }
}