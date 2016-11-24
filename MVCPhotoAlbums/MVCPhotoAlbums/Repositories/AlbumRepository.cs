using MVCPhotoAlbums.Models;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;

namespace MVCPhotoAlbums.Repositories
{
    public class AlbumRepository
    {

        public static List<AlbumModel> _albums = new List<AlbumModel>();

        public AlbumModel ReturnAlbum(Guid albumId)
        {
            foreach (var user in UserRepository._users)
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

        internal static List<AlbumModel> GetAllAlbums()
        {
            return _albums;
        }

        internal AlbumModel CreateAlbum(AlbumModel albumToBeCreated, Guid userId)
        {
            //retrieve user that the album is getting created for
            UserRepository repo = new UserRepository();
            var albumOwner = repo.ReturnUserById(userId);

            albumToBeCreated.Id = Guid.NewGuid();
            albumToBeCreated.DateCreated = DateTime.Now;
            albumToBeCreated.Photos = new List<PhotoModel>();
            albumToBeCreated.User = albumOwner;

            albumOwner.Albums.Add(albumToBeCreated);

            return albumToBeCreated;
        }

        internal static void AddCommentToAlbum(Guid albumid, CommentModel newAlbumComment)
        {
            foreach (var a in _albums)
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