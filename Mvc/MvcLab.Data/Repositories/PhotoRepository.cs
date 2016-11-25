using System;
using System.Collections.Generic;
using MvcLab.Data.Models;

namespace MvcLab.Data.Repositories
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
        public static List<PhotoModel> GetAllPhotos()
        {
            List<PhotoModel> photos = new List<PhotoModel>();

            foreach (var user in UserRepository.Users)
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

        /// <summary>
        /// return the correct photo when we find it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhotoModel ReturnPhoto(Guid id)
        {
            foreach (var user in UserRepository.Users)
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
    }
}