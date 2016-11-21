using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPhotoAlbums.Models
{
    public class AlbumModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<PhotoModel> Photos { get; set; }
    }
}