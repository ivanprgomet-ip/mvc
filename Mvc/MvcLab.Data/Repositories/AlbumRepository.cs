using System;
using System.Collections.Generic;
using MvcLab.Data.Models;
using System.Linq;

namespace MvcLab.Data.Repositories
{
    public class AlbumRepository
    {
        public static List<AlbumModel> Albums { get; private set; } = new List<AlbumModel>();

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

        public List<AlbumModel> GetAllAlbums()
        {
            return Albums;
        }

        public AlbumModel CreateAlbum(AlbumModel albumToBeCreated, Guid userId)
        {
            //get the user
            UserRepository repo = new UserRepository();
            var albumOwner = repo.Return(userId);

            //set the important album properties
            albumToBeCreated.Id = Guid.NewGuid();
            albumToBeCreated.DateCreated = DateTime.Now;
            albumToBeCreated.Photos = new List<PhotoModel>();
            albumToBeCreated.User = albumOwner;

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