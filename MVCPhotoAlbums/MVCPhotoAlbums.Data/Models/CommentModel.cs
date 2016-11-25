using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPhotoAlbums.Data.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }

        public PhotoModel Photo { get; set; }
        public AlbumModel Album { get; set; }
    }
}