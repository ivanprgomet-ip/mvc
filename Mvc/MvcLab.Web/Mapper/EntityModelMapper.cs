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
        public static AlbumEntity ModelToEntity(AlbumModel model)
        {
            AlbumEntity entity = new AlbumEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated,
            };

            return entity;
        }
        public static AlbumModel EntityToModel(AlbumEntity entity)
        {
            AlbumModel model = new AlbumModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
            };

            return model;
        }

        public static CommentEntity ModelToEntity(CommentModel model)
        {
            CommentEntity entity = new CommentEntity()
            {
                Id = model.Id,
                Comment = model.Comment,
                DateCreated = model.DateCreated,
            };

            return entity;
        }
        public static CommentModel EntityToModel(CommentEntity entity)
        {
            CommentModel model = new CommentModel()
            {
                Id = entity.Id,
                Comment = entity.Comment,
                DateCreated = entity.DateCreated,
            };

            return model;
        }
    }
}
