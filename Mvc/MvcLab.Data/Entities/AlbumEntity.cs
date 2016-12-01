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
        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<PhotoEntity> Photos { get; set; }

        public virtual UserEntity User { get; set; }

        public AlbumEntity()
        {
            Comments = new List<CommentEntity>();
            Photos = new List<PhotoEntity>();
        }
    }
}