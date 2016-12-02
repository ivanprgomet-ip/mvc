using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcLab.Data.Models
{
    public class PhotoEntity
    {
        [Key]
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        public string UploadedBy { get; set; }

        //navigation property
        public virtual List<CommentEntity> Comments { get; set; }

        //navigation properties and foreign key properties
        public virtual UserEntity User { get; set; }
        public int? UserId { get; set; }
        public virtual AlbumEntity Album { get; set; }
        public int? AlbumId { get; set; }

        public PhotoEntity()
        {
            Comments = new List<CommentEntity>();
        }
    }
}