using MVCPhotoAlbums.Models;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web;

namespace MVCPhotoAlbums.Repositories
{
    public class AlbumRepository
    {
        public AlbumModel ReturnAlbum(Guid albumId)
        {
            foreach (var user in UserRepository._users)
            {
                foreach (var userAlbum in user.Albums)
                {
                    if(userAlbum.Id == albumId)
                    {
                        return userAlbum;
                    }
                }
            }
            return null;
        }
    }
}