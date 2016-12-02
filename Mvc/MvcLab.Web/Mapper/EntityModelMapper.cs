using MvcLab.Data.Models;
using MvcLab.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Web.Mapper
{
    static class EntityModelMapper
    {
        public static UserEntity ModelToEntity(UserModel model)
        {
            UserEntity entity = new UserEntity()
            {
                UserId = model.UserId,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Street = model.Street,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                Phone = model.Phone,
                DateRegistered = model.DateRegistered,
                Username = model.Username,
                Password = model.Password,
            };

            return entity;
        }
        public static UserModel EntityToModel(UserEntity entity)
        {
            UserModel model = new UserModel()
            {
                UserId = entity.UserId,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                Street = entity.Street,
                City = entity.City,
                Country = entity.Country,
                Email = entity.Email,
                Phone = entity.Phone,
                DateRegistered = entity.DateRegistered,
                Username = entity.Username,
                Password = entity.Password,
            };

            return model;
        }
        public static AlbumEntity ModelToEntity(AlbumModel model)
        {
            AlbumEntity entity = new AlbumEntity()
            {
                AlbumId = model.AlbumId,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated,
                UserId = model.UserId,
            };

            return entity;
        }
        public static AlbumModel EntityToModel(AlbumEntity entity)
        {
            AlbumModel model = new AlbumModel()
            {
                AlbumId = entity.AlbumId,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                UserId = entity.UserId,

            };

            return model;
        }
        public static PhotoEntity ModelToEntity(PhotoModel model)
        {
            PhotoEntity entity = new PhotoEntity()
            {
                PhotoId = model.PhotoId,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated,
                FileName = model.FileName,
                UploadedBy = model.UploadedBy,
                AlbumId = model.AlbumId,
                UserId  = model.UserId,
            };

            return entity;
        }
        public static PhotoModel EntityToModel(PhotoEntity entity)
        {
            PhotoModel model = new PhotoModel()
            {
                PhotoId = entity.PhotoId,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                FileName = entity.FileName,
                UploadedBy = entity.UploadedBy,
                AlbumId = entity.AlbumId,
                UserId = entity.AlbumId,
            };

            return model;
        }
        public static CommentEntity ModelToEntity(CommentModel model)
        {
            CommentEntity entity = new CommentEntity()
            {
                CommentId = model.CommentId,
                Comment = model.Comment,
                DateCreated = model.DateCreated,
                AlbumId = model.AlbumId,
            };

            return entity;
        }
        public static CommentModel EntityToModel(CommentEntity entity)
        {
            CommentModel model = new CommentModel()
            {
                CommentId = entity.CommentId,
                Comment = entity.Comment,
                DateCreated = entity.DateCreated,
                AlbumId = entity.AlbumId,
                PhotoId = entity.PhotoId,
            };

            return model;
        }
    }
}
