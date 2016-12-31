using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Data.Entities
{
    public class CommentEntityModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public string Commenter { get; set; } 

        public virtual PhotoEntityModel Photo { get; set; } //one side
        public virtual AlbumEntityModel Album { get; set; } //one side

    }
}