using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLab.Data.Models
{
    public class AlbumEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<PhotoEntity> Photos { get; set; }

        public UserEntity User { get; set; }
    }
}