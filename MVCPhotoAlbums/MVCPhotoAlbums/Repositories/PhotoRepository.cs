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

        /// <summary>
        /// return list of all photos from all users
        /// </summary>
        /// <returns></returns>
        internal static List<PhotoModel> GetAllPhotos()
        {
            List<PhotoModel> photos = new List<PhotoModel>();

            foreach (var user in UserRepository._users)
            {
                foreach (var album in user.Albums)
                {
                    foreach (var photo in album.Photos)
                    {
                        //setting the properties right
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
    }
}