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
        public List<CommentEntity> Comments { get; set; }

        public UserEntity User { get; set; }
        public AlbumEntity Album { get; set; }
    }
}