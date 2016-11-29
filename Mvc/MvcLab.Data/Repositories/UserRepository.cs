using System;
using System.Collections.Generic;
using System.Linq;
using MvcLab.Data.Models;
using System.IO;

namespace MvcLab.Data.Repositories
{
    /// <summary>
    /// all data retrieval goes through the user to avoid nullref exceptions, 
    /// because users have albums, and albums have photos and comments
    /// </summary>
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
        /// Initializer method
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
        /// Initializer method
        /// </summary>
        private void SetupInitialUserFolders()
        {
            //server mappath doesnt work here, using alternative to get basedir (instead of ~)
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string destination = string.Format($"{baseDir}/UsersData/");

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var user in Users)
            {
                string individualUserDir = Path.Combine(destination, user.Username);
                Directory.CreateDirectory(individualUserDir);

                foreach (var album in user.Albums)
                {
                    string IndividualUserAlbumDir = Path.Combine(individualUserDir, album.Name);
                    Directory.CreateDirectory(IndividualUserAlbumDir);

                    //in the future, photos get saved from the user interface using input type file
                }
            }
        }

        public void CreateUser(UserModel userToBeRegistered)
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
        public UserModel GetUser(Guid userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public UserModel GetLoggedInUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        //------------------------------------PHOTOS------------------------------------
        public void CreatePhoto(PhotoModel photo)
        {
            //todo: what is the point of this method??
            photo.DateCreated = DateTime.Now;
            photo.Id = Guid.NewGuid();
        }

        public void DeletePhoto(PhotoModel photo)
        {
            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    foreach (var p in album.Photos)
                    {
                        if(p.Id == photo.Id)
                        {
                            album.Photos.Remove(photo); //remove the photo from the album
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// return list of all photos from all users
        /// </summary>
        /// <returns></returns>
        public List<PhotoModel> GetAllPhotos()
        {
            List<PhotoModel> photos = new List<PhotoModel>();

            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    foreach (var photo in album.Photos)
                    {
                        PhotoModel current = new PhotoModel();
                        current = photo;
                        current.Album = album;
                        current.User = user;

                        photos.Add(photo);
                    }
                }
            }
            return photos;
        }

        /// <summary>
        /// return the correct photo when we find it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhotoModel GetPhoto(Guid id)
        {
            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    foreach (var photo in album.Photos)
                    {
                        if (photo.Id == id)
                            return photo;
                    }
                }
            }
            return null;
        }

        //------------------------------------ALBUMS------------------------------------
        public AlbumModel GetAlbum(Guid albumId)
        {
            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    if (album.Id == albumId)
                    {
                        return album;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// return list of all albums from all users
        /// </summary>
        /// <returns></returns>
        public List<AlbumModel> GetAllAlbums()
        {
            List<AlbumModel> albums = new List<AlbumModel>();

            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    //AlbumModel currentAlbum = new AlbumModel();
                    //currentAlbum = album;
                    albums.Add(album);
                }
            }
            return albums;
        }

        public AlbumModel CreateAlbum(AlbumModel newAlbum, Guid userId)
        {
            //get the owner of the album
            var albumUser = Users.Where(u => u.Id == userId).FirstOrDefault();

            //set some properties of the new album
            newAlbum.Id = Guid.NewGuid();
            newAlbum.DateCreated = DateTime.Now;
            newAlbum.Photos = new List<PhotoModel>();
            newAlbum.User = albumUser;
            newAlbum.Comments = new List<CommentModel>();

            //add the album to the users albums
            albumUser.Albums.Add(newAlbum);

            return newAlbum;
        }

        public void CreateAlbumComment(Guid albumid, CommentModel newAlbumComment)
        {
            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    if (album.Id == albumid)
                    {
                        album.Comments.Add(newAlbumComment);
                        break;
                    }
                }
                
            }

        }
    }
}