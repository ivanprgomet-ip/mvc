using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcLab.Data.Models
{
    public class AlbumEntity
    {
        [Key]
        public Guid AlbumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        //navigation properties
        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<PhotoEntity> Photos { get; set; }

        //navigation property and foreign key property
        public virtual UserEntity User { get; set; }
        public Guid UserId { get; set; }

        public AlbumEntity()
        {
            Comments = new List<CommentEntity>();
            Photos = new List<PhotoEntity>();
        }
    }
}