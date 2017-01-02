using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoExplorer.Data.Entities;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.helpers
{
    public class EFMapper
    {
        public static UserDetailsViewModel EntityToModel(UserEntityModel entity)
        {
            UserDetailsViewModel model = new UserDetailsViewModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Fullname = entity.Fullname,
                Albums = entity.Albums,
                DateRegistered = entity.DateRegistered,
                Email = entity.Email,
            };

            return model;
        }
        public static AlbumDetailsViewModel EntityToModel(AlbumEntityModel entity)
        {
            AlbumDetailsViewModel model = new AlbumDetailsViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Comments = entity.Comments,
                DateCreated = entity.DateCreated,
                Description = entity.Description,
                Photos = entity.Photos,
                User = entity.User,
            };

            return model;
        }
        public static PhotoDetailsViewModel EntityToModel(PhotoEntityModel entity)
        {
            PhotoDetailsViewModel model = new PhotoDetailsViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                FileName = entity.FileName,
                DateCreated = entity.DateCreated,
                DateChanged = entity.DateChanged,
                Album = entity.Album,
                Comments = entity.Comments,
                Description = entity.Description,
                User = entity.User,
            };

            return model;
        }
    }
}