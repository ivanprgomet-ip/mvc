using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }

        public virtual PhotoViewModel Photo { get; set; }
        //public int PhotoModelId { get; set; }
        public virtual AlbumViewModel Album { get; set; }
        //public int AlbumModelId { get; set; }
    }
}