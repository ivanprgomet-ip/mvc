using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLab.Data.Models
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }

        //navigation properties and foreign key properties
        public virtual PhotoEntity Photo { get; set; }
        public int PhotoId { get; set; }
        public virtual AlbumEntity Album { get; set; }
        public int AlbumId { get; set; }
    }
}