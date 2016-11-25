using System;
using System.Collections.Generic;
using System.Linq;
using MvcLab.Data.Models;
using System.IO;

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
                SetupInitialUserFolders();
            }
        }

        /// <summary>
        /// create some default users for the application
        /// </summary>
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
            #region creating album for Ivan
            u1.Albums.Add(new AlbumModel()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = "Coding Events",
                Description = "Photos from some coding events that I have attended",
                Photos = new List<PhotoModel>(),
                Comments = new List<CommentModel>(),
                User = u1,
            });
            #endregion

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
            #region creating album for Lea (files added in album folder before startup, later files get added thru mvc UI input type file)
            u2.Albums.Add(new AlbumModel()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = "Lea Coding Album",
                Description = "No Album Description",
                Photos = new List<PhotoModel>() {
                    new PhotoModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "coffe is love",
                                FileName = "code2.jpg",
                                DateCreated = DateTime.Now,
                                Description = "No Photo Description",
                                Comments = new List<CommentModel>(),
                            },
                    new PhotoModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "think before you code",
                                FileName = "code4.png",
                                DateCreated = DateTime.Now,
                                Description = "you should never mix code with alcohol",
                                Comments = new List<CommentModel>(),
                            },
                    new PhotoModel()
                            {
                                Id = Guid.NewGuid(),
                                Name = "no place like home",
                                FileName = "code5.jpg",
                                DateCreated = DateTime.Now,
                                Description = "No Photo Description",
                                Comments = new List<CommentModel>(),
                            },
                },
                Comments = new List<CommentModel>(),
                User = u2,
            });
            #endregion


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
        }

        /// <summary>
        /// Create folders based on existing users
        /// </summary>
        private void SetupInitialUserFolders()
        {
            //where all data files will be for the users of the application
            //string destination = Server.MapPath("~/UsersData/");

            //server mappath doesnt work here, using alternative to get basedir
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string destination = string.Format($"{baseDir}/UsersData/");


            //create the destination folder if it doesnt exist
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var user in UserRepository.Users)
            {
                string individualUserDir = Path.Combine(destination, user.Username);
                Directory.CreateDirectory(individualUserDir);

                foreach (var album in user.Albums)
                {
                    string IndividualUserAlbumDir = Path.Combine(individualUserDir, album.Name);
                    Directory.CreateDirectory(IndividualUserAlbumDir);

                    //photos get saved from the user interface using input type file
                }
            }
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
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}