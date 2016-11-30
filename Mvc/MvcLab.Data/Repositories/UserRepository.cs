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
        //save in memory until we move to a database
        public static IList<UserEntity> Users { get; private set; } = new List<UserEntity>();

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
            UserEntity u1 = new UserEntity()
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

                Albums = new List<AlbumEntity>(),
            };
            #region creating album for Ivan
            u1.Albums.Add(new AlbumEntity()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = "Coding Events",
                Description = "Photos from some coding events that I have attended",
                Photos = new List<PhotoEntity>(),
                Comments = new List<CommentEntity>(),
                User = u1,
            });
            #endregion

            UserEntity u2 = new UserEntity()
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

                Albums = new List<AlbumEntity>(),
            };
            #region creating album for Lea (files added in album folder before startup, later files get added thru mvc UI input type file)
            u2.Albums.Add(new AlbumEntity()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = "Lea Coding Album",
                Description = "No Album Description",
                Photos = new List<PhotoEntity>() {
                    new PhotoEntity()
                            {
                                Id = Guid.NewGuid(),
                                Name = "coffe is love",
                                FileName = "code2.jpg",
                                DateCreated = DateTime.Now,
                                Description = "No Photo Description",
                                Comments = new List<CommentEntity>(),
                            },
                    new PhotoEntity()
                            {
                                Id = Guid.NewGuid(),
                                Name = "think before you code",
                                FileName = "code4.png",
                                DateCreated = DateTime.Now,
                                Description = "you should never mix code with alcohol",
                                Comments = new List<CommentEntity>(),
                            },
                    new PhotoEntity()
                            {
                                Id = Guid.NewGuid(),
                                Name = "no place like home",
                                FileName = "code5.jpg",
                                DateCreated = DateTime.Now,
                                Description = "No Photo Description",
                                Comments = new List<CommentEntity>(),
                            },
                },
                Comments = new List<CommentEntity>(),
                User = u2,
            });
            #endregion


            UserEntity u3 = new UserEntity()
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

                Albums = new List<AlbumEntity>(),
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

        /// <summary>
        /// register a new user. successfully adds user to the database.
        /// </summary>
        /// <param name="userToBeRegistered"></param>
        public void Add(UserEntity userToBeRegistered)
        {
            userToBeRegistered.Id = Guid.NewGuid();

            userToBeRegistered.DateRegistered = DateTime.Now;

            userToBeRegistered.Albums = new List<AlbumEntity>();

            Users.Add(userToBeRegistered);
        }

        /// <summary>
        /// return a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserEntity GetUser(Guid userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public UserEntity GetLoggedInUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public List<UserEntity> GetAllUsers()
        {
            List<UserEntity> users = new List<UserEntity>();

            foreach (var user in Users)
            {
                users.Add(user); //todo: also include related data
            }
            return users;
        }

        //------------------------------------PHOTOS------------------------------------
        public void CreatePhoto(PhotoEntity photo)
        {
            //todo: what is the point of this method??
            photo.DateCreated = DateTime.Now;
            photo.Id = Guid.NewGuid();
        }

        public void DeletePhoto(PhotoEntity photo)
        {
            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    foreach (var p in album.Photos)
                    {
                        if (p.Id == photo.Id)
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
        public List<PhotoEntity> GetAllPhotos()
        {
            List<PhotoEntity> photos = new List<PhotoEntity>();

            foreach (var user in Users)
            {
                foreach (var album in user.Albums)
                {
                    foreach (var photo in album.Photos)
                    {
                        PhotoEntity current = new PhotoEntity();
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
        public PhotoEntity GetPhoto(Guid id)
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
        public AlbumEntity GetAlbum(Guid albumId)
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
        public List<AlbumEntity> GetAllAlbums()
        {
            List<AlbumEntity> albums = new List<AlbumEntity>();

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

        public AlbumEntity Add(AlbumEntity newAlbum, Guid userId)
        {
            //get the owner of the album
            var albumUser = Users.Where(u => u.Id == userId).FirstOrDefault();

            //set some properties of the new album
            newAlbum.Id = Guid.NewGuid();
            newAlbum.DateCreated = DateTime.Now;
            newAlbum.Photos = new List<PhotoEntity>();
            newAlbum.User = albumUser;
            newAlbum.Comments = new List<CommentEntity>();

            //add the album to the users albums
            albumUser.Albums.Add(newAlbum);

            return newAlbum;
        }

        public void CreateAlbumComment(Guid albumid, CommentEntity newAlbumComment)
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