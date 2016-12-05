using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Entities
{
    public class CommentEntityModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }

        public virtual PhotoEntityModel Photo { get; set; }
        public virtual AlbumEntityModel Album { get; set; }
    }
}