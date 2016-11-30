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

        public PhotoEntity Photo { get; set; }
        public AlbumEntity Album { get; set; }
    }
}