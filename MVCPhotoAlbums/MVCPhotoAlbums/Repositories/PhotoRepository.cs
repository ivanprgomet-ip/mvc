using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPhotoAlbums.Models;

namespace MVCPhotoAlbums.Repositories
{
    public class PhotoRepository
    {
        internal void CreatePhoto(PhotoModel photo)
        {
            photo.DateCreated = DateTime.Now;
            photo.Id = Guid.NewGuid();
        }

        internal void DeletePhoto(PhotoModel photo)
        {
            AlbumRepository repo = new AlbumRepository();
            var album = repo.ReturnAlbum(photo.Id);//retrieve the album containing the photo
            album.Photos.Remove(photo);//remove the photo from the album
        }
    }
}