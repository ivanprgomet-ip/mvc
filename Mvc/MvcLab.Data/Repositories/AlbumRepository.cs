using System;
using System.Collections.Generic;
using MvcLab.Data.Models;
using System.Linq;

namespace MvcLab.Data.Repositories
{
    public class AlbumRepository
    {
        public static List<AlbumModel> Albums { get; private set; } = new List<AlbumModel>();

        /// <summary>
        /// the albumrepository constructor initializes the albums list
        /// </summary>
        public AlbumRepository()
        {
            //if the albums list is empty, initalize it based on existing user albums
            if (!Albums.Any())
            {
                //set the albums list here based on the existent users
                UserRepository UserRepository = new UserRepository();
                foreach (var user in UserRepository.Users)
                {
                    foreach (var album in user.Albums)
                    {
                        Albums.Add(album);
                    }
                }

            }
        }

        public AlbumModel ReturnAlbum(Guid albumId)
        {
            foreach (var user in UserRepository.Users)
            {
                foreach (var userAlbum in user.Albums)
                {
                    if (userAlbum.Id == albumId)
                    {
                        return userAlbum;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// return list of all albums froma all users
        /// </summary>
        /// <returns></returns>
        public List<AlbumModel> GetAllAlbums()
        {
            List<AlbumModel> albums = new List<AlbumModel>();

            foreach (var user in UserRepository.Users)
            {
                foreach (var album in user.Albums)
                {
                    AlbumModel currentAlbum = new AlbumModel();
                    currentAlbum = album;
                    albums.Add(album);
                }
            }
            return albums;
        }

        public AlbumModel CreateAlbum(AlbumModel albumToBeCreated, Guid userId)
        {
            //get the user
            UserRepository userRepo = new UserRepository();
            var albumOwner = userRepo.Return(userId);

            //set the important album properties
            albumToBeCreated.Id = Guid.NewGuid();
            albumToBeCreated.DateCreated = DateTime.Now;
            albumToBeCreated.Photos = new List<PhotoModel>();
            albumToBeCreated.User = albumOwner;
            albumToBeCreated.Comments = new List<CommentModel>();

            albumOwner.Albums.Add(albumToBeCreated);

            return albumToBeCreated;
        }

        internal static void AddCommentToAlbum(Guid albumid, CommentModel newAlbumComment)
        {
            foreach (var a in Albums)
            {
                if (a.Id == albumid)
                {
                    a.Comments.Add(newAlbumComment);
                    break;
                }
            }
        }
    }
}