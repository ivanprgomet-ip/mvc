using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
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
        private static AlbumRepository albumRepo = new AlbumRepository();
        public static UserEntity ModelToEntity(UserModel model)
        {

            UserEntity entity = new UserEntity()
            {
                UserEntityId = model.UserModelId,
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
            //mapping simple properties
            UserModel model = new UserModel()
            {
                UserModelId = entity.UserEntityId,
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

            //mapping albums collection separately
            List<AlbumModel> albumModels = new List<AlbumModel>();

            foreach (var albumEntity in entity.Albums)
            {
                albumModels.Add(EntityToModel(albumEntity));
            }

            model.Albums = albumModels;

            return model;
        }
        public static AlbumEntity ModelToEntity(AlbumModel model)
        {
            AlbumEntity entity = new AlbumEntity()
            {
                AlbumEntityId = model.AlbumModelId,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated,
                UserEntityId = model.UserModelId,
            };

            return entity;
        }
        public static AlbumModel EntityToModel(AlbumEntity entity)
        {
            AlbumModel model = new AlbumModel()
            {
                AlbumModelId = entity.AlbumEntityId,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                UserModelId = entity.UserEntityId,
            };

            return model;
        }
        public static PhotoEntity ModelToEntity(PhotoModel model)
        {
            PhotoEntity entity = new PhotoEntity()
            {
                PhotoEntityId = model.PhotoModelId,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated,
                FileName = model.FileName,
                UploadedBy = model.UploadedBy,
                AlbumEntityId = model.AlbumModelId,
                UserEntityId = model.UserModelId,
            };

            return entity;
        }
        public static PhotoModel EntityToModel(PhotoEntity entity)
        {
            PhotoModel model = new PhotoModel()
            {
                PhotoModelId = entity.PhotoEntityId,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                FileName = entity.FileName,
                UploadedBy = entity.UploadedBy,
                AlbumModelId = entity.AlbumEntityId,
                UserModelId = entity.AlbumEntityId,
            };

            return model;
        }
        public static CommentEntity ModelToEntity(CommentModel model)
        {
            CommentEntity entity = new CommentEntity()
            {
                CommentEntityId = model.CommentModelId,
                Comment = model.Comment,
                DateCreated = model.DateCreated,
                AlbumEntityId = model.AlbumModelId,
            };

            return entity;
        }
        public static CommentModel EntityToModel(CommentEntity entity)
        {
            CommentModel model = new CommentModel()
            {
                CommentModelId = entity.CommentEntityId,
                Comment = entity.Comment,
                DateCreated = entity.DateCreated,
                AlbumModelId = entity.AlbumEntityId,
                PhotoModelId = entity.PhotoEntityId,
            };

            return model;
        }
    }
}
