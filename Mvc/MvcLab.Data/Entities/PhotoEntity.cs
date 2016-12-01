using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLab.Data.Models
{
    public class PhotoEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        public string UploadedBy { get; set; }
        public virtual List<CommentEntity> Comments { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual AlbumEntity Album { get; set; }

        public PhotoEntity()
        {
            Comments = new List<CommentEntity>();
        }
    }
}