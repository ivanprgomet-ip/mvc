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
    }
}